#include <stdio.h>
#include <syslog.h>


int main(){
    FILE *log = fopen("log.log", "w+");
    if(!log) perror("file is fucked");
    
    LOG(log, "FUCKING SUKA BLIAT");
    
    fclose(log);
    return 0;
}