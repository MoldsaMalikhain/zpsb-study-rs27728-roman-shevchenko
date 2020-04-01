#include <stdio.h>
#include <string.h>
#include <unistd.h>
#include <sys/types.h>
#include <signal.h>
#define CHAR 2048

FILE *initFile(){
    FILE *IFile;
    IFile = fopen("input.txt", "r");
    if(!IFile) perror("err in file read");
    printf("Text init\n");
    return IFile;
}
int lineCounter(FILE *iFile){
    int counter = 0;
    while (!feof(iFile)) if(fgetc(iFile) == '\n') counter++;
    counter ++;
    printf("%d\n", counter);
    return counter;
}
int spaceCounter(FILE *iFile, int crLine, int lines, int pid){
    if(crLine < lines){
        int counter = 0;
        char text[CHAR];
        for (int i = 0; i<crLine; i++){
            fgets (text, CHAR, iFile);
        }
        for(int k = 0; k < strlen(text); k++){
            if(text[k] == ' ') counter++;
            else if(text[k] == '\0') break;
        }
        printf("PID: %d line %d have %d spaces\n",pid,crLine,counter);
    }
    return 0;
}
int forkExecute(FILE *iFile, int lines, int crLine){
    while(1){
        pid_t pid;
        int f = fork();
        if(f < 0){
            printf("err");
            return -1;
        }else if(f == 0){
            pid = getpid();
            spaceCounter(iFile, crLine, lines, pid);
        }else{
            if(crLine < lines){
                crLine++;
                kill(pid, SIGKILL);
            }else break;
        }
    }
    return 0;
}
int main(){
    FILE *iFile = initFile();    
    int crLine  = 0;
    int lines   = lineCounter(iFile);
    forkExecute(iFile, lines, crLine);
    fclose(iFile);
    return 0;
}
