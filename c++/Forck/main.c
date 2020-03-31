#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <unistd.h>
#include <signal.h>
int line = 0;
int lines = 0;
int spaceCheck(FILE *iFile, char *text){
    unsigned short space;
    size_t len = 0;
    int line = 0;
    ssize_t read;
    while((read = getline(&text, &len, iFile) != -1)){
            *text = fgetc(iFile);
            if(feof(iFile)) break;
            for (size_t i = 0; i < strlen(text); i++)
            {
                if(text[i] == ' ') space++;
            }
            line ++;
            printf("w linii: %d jest %d spacji\n", line, space);
            space = 0;
            //if(*text == ' ') space++;
            //printf("Retrieved line of length %zu:\n", read);
            printf("%s", text);
        }
    fclose(iFile);
}

int main(int argc, char **argv){
    FILE *iFile;
    unsigned short i;
    char *text;
    
    iFile = fopen("input.txt", "r");
    if(!iFile) perror("Error opening file");
    else{
        while(1){
            int fo = fork();
            pid_t pid, childPid;

            pid = getpid(); 
        
            if(fo<0){
                printf("err");
                return 1;
            }
            else if(fo == 0){    
                printf("proces: %d\t", getpid());
                childPid = getpid();
                spaceCheck(iFile, text);
                return 0;
            }
            else{
                if(line < lines){
                    line ++;
                    kill(childPid,SIGKILL);
                }else{
                    break;
                }
            printf("parent pid: %d\n", pid);
            }
        }
        
    }
    return 0;
}