#include <stdio.h>
#include <unistd.h>
#include <sys/types.h>
#include <signal.h>

#define CHAR 2048

int crLine = 0;
int globalLines = 0;

FILE *initFile(){
    FILE * iFile;
    iFile = fopen("input.txt","r");
    if (iFile == NULL) perror("Error opening file");
    return iFile;
}
int spaceCheck(FILE * iFile,int rLine, int pid){
    if (rLine < globalLines){
        char text[CHAR];
        int counter = 0;
        iFile = fopen("input.txt","r");
        for (int i = 0; i<rLine; i++){
            fgets (text,CHAR,iFile);
        }
        for (int k = 0; k < CHAR; k++){
            if(text[k] == ' ')counter++;
            else if (text[k] == '\0')break;
        }
        printf("proces: %d; w linii: %d jest: %d spacji\n", pid, rLine, counter);
    }
    return 0;
}
int lineCounter(FILE * iFile){
    int counter = 0;
    while (!feof(iFile))if(fgetc(iFile) == '\n')counter++;
    counter++;
    return counter;
}
int newFork(FILE *iFile){
    while(1){
    pid_t pid;
    int fCheck = fork();
        if(fCheck < 0){
            printf("Fork Error");
            return -1;
        }else if (fCheck == 0) {
            pid = getpid();
            spaceCheck(iFile, crLine, pid);
            return 0;
        }else{
            if (crLine < globalLines){
                crLine++;
                kill(pid, SIGKILL);
            }else break;
        }
    }    
    return 0;
}
int main (){
    FILE *iFile = initFile();
    globalLines = lineCounter(iFile);
    newFork(iFile);
}
