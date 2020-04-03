#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<dirent.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>


int main(int argc, char **argv)
{
    int counter = 0;
    if(argc != 2)
    {
        printf("\n Please pass in the directory name \n");      
        return 1;
    }
    DIR *path = NULL;
    struct dirent *dPath = NULL;
    char buff[128] = {0};                                       // buffer for storing directory path
    strcpy(buff, argv[1]);                                      // copy the pass 
    
    if(!(path = opendir(argv[1])))
    {
        printf("\n Cannot open input derectory [%s]\n",argv[1]);// derectory is fucked
        exit(1);
    }
    else
    {
        if(buff[strlen(buff) - 1] == '/')
            strcat(buff,"newDir/");
        
        else strcat(buff,"/newDir/");
    
        while(NULL != (dPath = readdir(path)))
        { 
            printf("[%s]", dPath -> d_name); 
            counter++;
        }                                                       //dir output
        printf("\n%d\n", counter);
        closedir(path);
    }
    printf("\n");
    return counter;
}

/*
void dirs_in_dir(const wchar_t * szDir) {
    wchar_t sTryPath[FILENAME_MAX];
    wcscpy(sTryPath, szDir);
    wcscat(sTryPath, L"\\*");
    WIN32_FIND_DATA wf = {0};
    HANDLE hFile = FindFirstFile(sTryPath, &wf);
    if (hFile == INVALID_HANDLE_VALUE) return;
    do {
        if (wf.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY) {
            if ((wcscmp(wf.cFileName, L"." ) != 0) && 
                (wcscmp(wf.cFileName, L"..") != 0))
            {
                // обрабатываем только директории
                //SendMessage(hList, LB_ADDSTRING, 0, (LPARAM)wf.cFileName);
            }
        }
    } while (FindNextFile(hFile, &wf) != 0);
    FindClose(hFile);
}
 
 
int _tmain(int argc, _TCHAR* argv[]) {
    dirs_in_dir(L"C:\\Windows");
}
*/