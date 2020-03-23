#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <getopt.h>

void reverse(char s[]){
    int i,j;
    char ch;

    for(i = 0, j = strlen(s)-1; i < j; i++, j--){
        ch = s[i];
        s[i] = s[j];
        s[j] = ch;
    }
}
void gen(int num, char s[]){
    int i, nSign;
    if((nSign = num) < 0)
        num = -num;
    i = 0;
    do{
        s[i++] = num % 10 + '0';
    } while((num /= 10) > 0);
    if(nSign < 0)
        s[i++] = '-';
    s[i] = '\0';
    reverse(s);
}

int main(int argc, char **argv){
    int rez=0;
    char input[15];
    char output[15];
    char string[10];
    FILE *iFile, *oFile;
    int counter = 0;
    char ch;

    while((rez = getopt(argc,argv,"i:o:o:i:")) != -1){
        switch(rez){
            case 'i': 
                printf("found arg \"i = %s\".\n", optarg);
                strcpy(input,optarg);
                break;
            case 'o':
                printf("found arg \"o = %s\".\n", optarg);
                strcpy(output, optarg);
                break;
            case '?' :
                printf("Error \n");
                break;
        };
    };
    iFile= fopen(input, "r");
    if(!iFile) perror("Error");
    else{
        while(1){
            ch = fgetc(iFile);
            if (feof(iFile)) break;
            if(ch == 'x') counter ++;
        }
    }
    oFile = fopen(output,"w+");
    gen(counter,string);
    fputs(string, oFile);
    fcloseall();
    printf("%d\n", counter);

    return 0;
    printf("%s\n", input);
    printf("%s",output);
};