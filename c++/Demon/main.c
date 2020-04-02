#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <syslog.h>

int daemonCall(ssize_t msTime, char *path){


    return 0;
}

static void skeleton_daemon(){
}

int main(int argc, char **argv){


    while (1)
    {
        skeleton_daemon();

        //TODO: Insert daemon code here.
        syslog (LOG_NOTICE, "First daemon started.");
        sleep (20);
        break;
    }

    syslog (LOG_NOTICE, "First daemon terminated.");
    closelog();

    return EXIT_SUCCESS;

    return 0;
}