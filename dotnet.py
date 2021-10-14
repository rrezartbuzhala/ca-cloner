import os
import sys
import shutil
import constants
from os import path
from helpers import read_config

app_name = sys.argv[1]


#Copying the template
try:
   src = 'templates/'+ sys.argv[2]
except:
    src = 'templates/' + read_config(constants.default_template)
    
dir_dest = read_config("DESTINATION_OUTPUT") + "\\"
dest = dir_dest + app_name+'/'
shutil.copytree(src, dest) 


project_dir = dest
project_dir_src = project_dir + 'src/'
os.chdir(project_dir)

file_ext = lambda file : os.path.splitext(file)[1]


def change_keywords_in_file(filepath):
    file = open(filepath,'r')
    filedata = file.read()
    file.close()

    newdata = filedata.replace(constants.keyword,app_name)

    file = open(filepath,'w')
    file.write(newdata)
    file.close()

def change_files_rec(current_path):
    for i in os.listdir(current_path):
        new_name = i
        if constants.keyword in i:
            new_name = i.replace(constants.keyword,app_name)
            os.rename(current_path+i,current_path+new_name)
        if path.isfile(current_path+new_name):
            change_keywords_in_file(current_path+new_name)
        else:
            change_files_rec(current_path+new_name+'/')


#Recuresively changing all solution name references for all files
change_files_rec(project_dir)

print('Application created at: '+dest)
print("Enjoy codeing")
