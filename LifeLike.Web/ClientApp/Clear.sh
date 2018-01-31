#!/usr/bin/env bash
find . -name "*.jsx" -type f -print0 -maxdepth 4 | xargs -0 /bin/rm -f
