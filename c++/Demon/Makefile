binary: main.o libDirFinder.a
	gcc -o binary main.o -L -libDirFinder
main.o: main.c
	gcc -c main.c
libDirFinder.a: dirFinder.o
	ar cr libDirFinder.a dirFinder.o
dirFinder.o: dirFinder.c
	gcc -c dirFinder.c
clean: rm -f *.o *.a binary
