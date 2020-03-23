binary: Index.o libMyMath.so
	gcc -o binary Index.o -L. -lMyMath -Wl,-rpath,.
Index.o: Index.c
	gcc -c Index.c
libMyMath.so: MyMath.o
	gcc -shared -o libMyMath.so MyMath.o 
MyMath.o: MyMath.c
	gcc -c -fPIC MyMath.c
clean:
	rm -f *.o *.so binary