#
# PROPRIETARY INFORMATION.  This software is proprietary to
# Side Effects Software Inc., and is not to be reproduced,
# transmitted, or disclosed in any way without written permission.
#
# Produced by:
#	Side Effects Software Inc
#	123 Front Street West, Suite 1401
#	Toronto, Ontario
#	Canada   M5J 2M2
#	416-504-9876
#
# NAME:	        job/hdaprocessor.py ( Python )
#
# COMMENTS:     Wrapper script for cooking HDAs
#

import os
import argparse
import re
import sys
import traceback
from subprocess import check_output, STDOUT, CalledProcessError
try:
    from pdgcmd import reportResultData
except ImportError:
    from pdgjob.pdgcmd import reportResultData

def main():
    parser = argparse.ArgumentParser(description=
"""
Cooks an HDA given an input json file.
Assumes json file is at $PDG_TEMP/data/$PDG_ITEM_NAME.json

If the HDA is a SOP, it will also save out the geometry.

Required environment:
    $PDG_SERVER_ADDR
    $PDG_ITEM_NAME
    $PDG_TEMP
    $PDG_DIR
    $HFS or $ORIGINAL_HFS

Required supporting module:
    pdgcmd.py
""")
    parser.add_argument('--pipe', required=False, type=str,
        help="Named pipe to use for HARS server")

    args = parser.parse_args()

    try:
        item_name = os.environ['PDG_ITEM_NAME']
        temp_dir = os.path.expandvars(os.environ['PDG_TEMP'])
        pdg_dir = os.path.expandvars(os.environ['PDG_DIR'])
    except KeyError:
        traceback.print_exc()
        sys.exit(1)

    # invoke HDAProcessor to do the work
    if 'HFS' in os.environ:
        bin_path = os.path.expandvars('$HFS/bin/HDAProcessor')
    else:
        bin_path = os.path.expandvars('$ORIGINAL_HFS/bin/HDAProcessor')
    argv = [bin_path, temp_dir, pdg_dir, item_name]
    if args.pipe:
        argv.extend(['--pipe', args.pipe])

    was_error = False

    try:
        output = check_output(argv, stderr=STDOUT)
    except CalledProcessError as ex:
        print('{}\nReturned error code {}:\n'.format(argv, ex.returncode))
        output = ex.output
        was_error = True
    # scan for a result we should relay
    match = re.search(r'PDG_RESULT: (.*) : (.*)$', output, re.MULTILINE)
    if match:
        output_file = match.group(1)
        output_tag = match.group(2)
        reportResultData(output_file, result_data_tag=output_tag, to_stdout=False)
    print(output)
    sys.stdout.flush() 

    if was_error:
        exit(1)

if __name__ == "__main__":
    main()
