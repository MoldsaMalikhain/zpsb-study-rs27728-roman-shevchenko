#include <stdio.h>
#include <signal.h>
#include <stdlib.h>
#include <unistd.h>

unsigned int sleep(unsigned int seconds);
int argA,argB;
void sigfunc(int sig) 
{
  char input;
  
  if(sig != SIGINT)return;
  
  else 
  {
    printf("\nDo you want exit from programm? (y/n)");
    input = getchar();
    
    if (input == 'y')exit(0);
    
    else if (input == 'n')return;
  }
} 
int main(int argc, char * argv[])
{
    signal(SIGINT, sigfunc);
    argA = atoi(argv[1]);
    argB = atoi(argv[2]);
    if (argA > argB)
    {
        while (1)
        {
            for (int i = argB; i < argA; i++)printf("%d\n",i);
            sleep(2);
        }
    } 
    else if(argA<argB) 
    {
        while (1)
        {
            for (int i = argA; i < argB; i++)printf("%d\n",i);
            sleep(2);
        }
    } 
    else return 0;
}