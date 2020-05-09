#!/bin/bash
if [[ $1 == "-p" ]]
then
    echo "Wpisz nazwe pliku i ilość plików"
else
read file
read counter

mkdir $file
for (( i=1; i <= $counter; i++ ))
do
    touch $file/$i
done
fi