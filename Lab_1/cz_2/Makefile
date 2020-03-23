binary: Index.o libMyMath.a
	gcc -o binary Index.o -L. -lMyMath

Index.o: Index.c
	gcc -c Index.c

libMyMath.a: MyMath.o
	ar cr libMyMath.a MyMath.o
MyMath.o: MyMath.c
	gcc -c MyMath.c

clean: rm -f *.o *.a binary