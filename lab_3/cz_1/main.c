#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>
#include <signal.h>
#include <sys/types.h>

int arg = 0;
int forckN; 
int newFork(int * pid, int cou)
{
    forckN = fork();
    pid_t childPid = forckN;
        if (forckN < 0)
        {
            printf("err in forck");
            return -1;
        } 
        else if (forckN == 0) while(1);
        else pid[cou] = forckN;         
        
    return 0;
}

int main (int argc, char * argv[]) 
{
    int counter = 0;
    arg = atoi(argv[1]);
    if (argc != 2)
    {
        printf("\nPlease enter amount of processes you would like to create!\n");
        return 1;
    }
    int pid[arg];

    for (int i = 0; i<arg; i++)pid[arg] = newFork(pid, i);
    

    int clock = 0;
    while(clock != -1)
    {
        if(counter == arg-1)
        {
            clock = -1;
            return 0;
        } 
        else 
        {
            counter = 0;
            for (int k = 0; k < arg; k++)
            {
                if (pid[k] != -1) printf("\nChild PID: %d\n",pid[k]);

                else if (pid[k] == -1)counter++;
            }
            printf("\nPID to kill process: ");
            int killPid;
            scanf("%d", &killPid);
            for (int i = 0; i < arg; i++)
            {
                if(killPid == pid[i]) 
                {
                    kill(killPid, 9);
                    pid[i] = -1;
                }
            }
        }
    }
    return 0;
}