#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <signal.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <syslog.h>

void logger(){

}

int dirFileCount(int argc, char **argv){
    int counter = 0;
    if(argc != 2){
        printf("\n Directory name requered\n");
        return -1;
    }
    DIR *path = NULL;
    struct  direct *dPath = NULL;
    char buff[128];
    memset(buff, 0, sizeof(buff));
    strcpy(buff, argv[1]);

    if(NULL == (path = opendir(argv[1]))){
        printf("\n err: directory canot be opend\n");
        exit(1);
    }else{
        if(buff[strlen(buff)-1] == '/')
            strcpy(buff + strlen(buff),"newDir/");
        
        else strcpy(buff + strlen(buff),"/newDir/");

        while(NULL !=(dPath = readdir(path))){
            counter++;
//            printf("[%s]\t", dPath -> d_name);
        }
        closedir(path);
    }
    
    return counter;
}

int daemonCall(ssize_t msTime){
    sleep(msTime);
    return 0;
}

static void skeleton_daemon(){
}

int main(int argc, char **argv){


    while (1)
    {
        skeleton_daemon();

        syslog (LOG_NOTICE, "First daemon started.");
        sleep (20);
        break;
    }

    syslog (LOG_NOTICE, "First daemon terminated.");
    closelog();

    return EXIT_SUCCESS;

    return 0;
}