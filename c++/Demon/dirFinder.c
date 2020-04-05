#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<dirent.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>

int main(int argc, char **argv){
    printf("%s %s %s", argv[0], argv[1], argv[2]);
    return 0;
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