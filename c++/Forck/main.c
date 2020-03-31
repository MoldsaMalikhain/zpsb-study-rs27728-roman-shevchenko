#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <sys/types.h>
#include <signal.h>
// global val
int lines =0;

FILE *initFile(){
    FILE *IFile;
    IFile = fopen("input.txt", "r");
    if(!IFile) perror("err in file read");
    return IFile;
}
int lineCounter(FILE *iFile){
    int counter = 0;
    while (!feof(iFile)) if(fgetc(iFile) == '\n') counter++;
    counter ++;
    return counter;
}
void spaceCheck(FILE *iFile, int line, pid_t pid){
    if(line < lines){
        int counter = 0;
        char *text;

        *text = fgetc(iFile);
        
        for (size_t i = 0; i < strlen(text); i++)
        {
            if(text[i] == ' ') counter++;
            else if(text[i] == '\0')break;
        }
        printf("\nPID: %d line %d have %d spaces\n",pid,line,counter);
    }
}
int newFork(FILE *iFile, int line){
    while(1){
        pid_t pid = getpid();
        int f = fork();
        if(f < 0){
            printf("err: forck()");
            return -1;
        }
        else if(f == 0){
            pid = getpid();
            spaceCheck(iFile, line, pid);
            return 0;
        }
        else{
            if(lines < line){
                line++;
                kill(pid,SIGKILL);
            }else break;
        }
    }
}
int main(){
    FILE *iFile = initFile();    
    int line = 0;
    lines = lineCounter(iFile);
    newFork(iFile, line);
    return 0;
}
