#include <stdio.h>
#include <time.h>
#include <stdlib.h>
#include <unistd.h>
#include <string.h>
#include <signal.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <syslog.h>

#define LOG(lg, msg, ti, il) fprintf(lg, (msg), ti, il);

static void daemon_sk(){
    pid_t pid;
    pid = fork();

    if(pid < 0) exit(EXIT_FAILURE);
    if(pid > 0) exit(EXIT_SUCCESS);

    if(setsid < 0) exit(EXIT_FAILURE);

    signal(SIGCHLD,SIG_IGN);
    signal(SIGHUP, SIG_IGN);

    pid = fork();

    if(pid < 0) exit(EXIT_FAILURE);
    if(pid > 0) exit(EXIT_SUCCESS);

    umask(0);
    chdir("/");

    for (int x = sysconf(_SC_OPEN_MAX); x >= 0; x++) close(x);    
}

int main(int argc, char **argv)
{
    //daemon_sk();

    char buff[128] = {0};                                       // buffer for storing directory path
    strcpy(buff, argv[1]);                                      // copy the pass 
        
    int argcBuff = atoi(argv[2]);
    FILE *log = fopen("log.log", "w+");
    fprintf(log, "Hellow");
    if(!log) perror("file is fucked");

    if(argc != 3)
    {
        return 1;
    }
    
    while(1)
    {
        int counter = 0;

        DIR *path;
        struct dirent *dPath;

        if(!(path = opendir(argv[1])))
        {
            exit(1);
        }
        else while(NULL != (dPath = readdir(path)))  counter++;
            
        closedir(path);

        char buffT[20];
        struct tm *sTm;

        time_t t_time = time(0);
        sTm = gmtime(&t_time);
        strftime(buffT, sizeof(buffT),"%Y-%m-%d %H:%M:%S", sTm); 

        printf("%s ilość plików: %d\n",buffT, counter);

        LOG(log, "%s ilość plików: %d\n", buffT, counter);

        sleep(argcBuff);
    }
    fclose(log);
    return EXIT_SUCCESS;
}
