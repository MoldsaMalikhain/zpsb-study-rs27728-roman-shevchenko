#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/types.h>
#include <unistd.h>
#include <signal.h>
int line = 0;
int lines = 0;
int spaceCheck(FILE *iFile, int lineN, pid_t childPid){
    if(lineN < lines){
        unsigned short space;
        size_t len = 0;
        int line = 0;
        ssize_t read;
        char *text;
        for (len; len < lineN;line++){
            *text = fgetc(iFile);
        }
        for(len = 0; len < strlen(text); len ++){
            if(text[len] == ' ') space ++;
            else if (text[len] == '\0') break;
        }
        printf("proces: %d; w linii: %d jest: %d spacji", childPid, lineN, space);
    }
    fclose(iFile);
    return 0;
}

int main(int argc, char **argv){
    FILE *iFile;
    unsigned short i;
    
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
                childPid = getpid();
                spaceCheck(iFile, line, childPid);
                return 0;
            }
            else{
                if(line < lines){
                    line ++;
                    kill(childPid,SIGKILL);
                }else{
                    break;
                }
            }
        }
        
    }
    return 0;
}
