#!/bin/bash

file=$1
sym=$2
echo "postacie $(cat $file | tr -cd "$sym" | wc -m)  w pliku $file"