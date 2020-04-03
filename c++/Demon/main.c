#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <signal.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <syslog.h>
#include "dirFinder.h"

#define LOG(lg, msg) fprintf(lg, "Some kind of bullshit (%d): ", time(0), (msg));


void logger(){
    
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