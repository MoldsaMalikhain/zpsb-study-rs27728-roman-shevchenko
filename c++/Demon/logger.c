#include <stdio.h>
#include <syslog.h>

#define LOG(lg, msg) fprintf(lg, "Some kind of bullshit (%d): ", time(0), (msg));

int main(){
    FILE *log = fopen("log.log", "w+");
    if(!log) perror("file is fucked");
    
    LOG(log, "FUCKING SUKA BLIAT");
    
    fclose(log);
    return 0;
}