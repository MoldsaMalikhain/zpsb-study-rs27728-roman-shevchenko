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

#define LOG(lg, ti, il) fprintf(lg, "%s ilość plików: %d\n", ti, il);





int main(int argc, char **argv)
{

    FILE *log = fopen("log.log", "w+");
    
    pid_t process_id = 0;
    pid_t sid        = 0;

    process_id = fork();

    printf("\n%d\n",process_id);
    
    if(process_id == 0)exit(0);
    else exit(1);
    
    umask(0);
    
    sid = setsid();

    if(sid < 0) exit(1);

    chdir("/");
    close(STDIN_FILENO);
    close(STDOUT_FILENO);
    close(STDERR_FILENO);

    if(argc != 3)
    {
            //printf("\n Please pass in the directory name \n");      
        return 1;
    }
    DIR *path = NULL;
    struct dirent *dPath = NULL;
    char buff[128] = {0};                                       // buffer for storing directory path
    strcpy(buff, argv[1]);                                      // copy the pass 
    int argcBuff = atoi(argv[2]);
    //printf("\n%d \n", argcBuff);
        
    if(!(path = opendir(argv[1])))
    {
        exit(1);
    }
    else
    {
        while(1)
        {
            int counter = 0;
            if(buff[strlen(buff) - 1] == '/')
                strcat(buff,"newDir/");
                
            else strcat(buff,"/newDir/");
            while(NULL != (dPath = readdir(path)))
            { 
                //printf("[%s]", dPath -> d_name); 
                counter++;
            }                                                       //dir output
                //closedir(path);
            //printf("\n");

            char buffT[20];
            struct tm *sTm;

            time_t t_time = time(0);
            sTm = gmtime(&t_time);
            strftime(buffT, sizeof(buffT),"%Y-%m-%d %H:%M:%S", sTm); 
            //printf("%s %d",buffT, counter);
            LOG(log,buffT, counter);
            sleep(argcBuff);
        }

        return EXIT_SUCCESS;
    }
    
}