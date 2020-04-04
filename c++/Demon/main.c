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
int main(int argc, char **argv)
{
    int argcBuff = argc;
    char **argvBuff = **argv; 
    FILE *log = fopen("log.log", "w+");

    pid_t process_id = 0;
    pid_t sid = 0;

    process_id = fork();

    if(process_id < 0)exit(1);
    if(process_id > 0)exit(0);
    umask(0);
    sid = setsid();
    if(sid < 0) exit(1);
    
    close(STDIN_FILENO);
    close(STDOUT_FILENO);
    close(STDERR_FILENO);



    while (1)
    {
        dirFileCount(argcBuff, **argvBuff);


        sleep (20);
        break;
    }

    closelog();

    return EXIT_SUCCESS;

    return 0;
}