#!/bin/bash

path = $1
depth = $2
cosnNum = 1

dirc = $(find $path -maxdepth $depth -type d -print | wc -l)
files = $(find $path -maxdepth $depth -type f -print | wc -l)

let "dirc = $dirc - $cosnNum"

echo "Directories: $dirc"
echo "Files: $files"