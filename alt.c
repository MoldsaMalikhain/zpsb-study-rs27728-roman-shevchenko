
int spaceCheck(FILE *iFile, char *text, int line){
    unsigned short space;
    size_t len = 0;
    int line = 0;
    ssize_t read;
    while((read = getline(&text, &len, iFile) != -1)){
            *text = fgetc(iFile);
            if(feof(iFile)) break;
            for (size_t i = 0; i < strlen(text); i++)
            {
                if(text[i] == ' ') space++;
            }
            line ++;
            printf("w linii: %d jest %d spacji\n", line, space);
            space = 0;
            //if(*text == ' ') space++;
            //printf("Retrieved line of length %zu:\n", read);
            printf("%s", text);
        }
    fclose(iFile);
}
