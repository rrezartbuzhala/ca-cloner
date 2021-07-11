import os
import sys
import shutil
from os import path

keyword = "[solutionName]"
app_name = sys.argv[2]

#Copying the template
src = 'templates/'+ sys.argv[1]
#Change 'dir_dest' to the directory where you want your project to be
dir_dest = '/home/rrezart/Desktop/'
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

    newdata = filedata.replace(keyword,app_name)

    file = open(filepath,'w')
    file.write(newdata)
    file.close()

def change_files_rec(current_path):
    for i in os.listdir(current_path):
    #TODO:replace the folder or file name whenever the keyword is matched
        if path.isfile(current_path+i):
            change_keywords_in_file(current_path+i)
        else:
            change_files_rec(current_path+i+'/')


#Changing solution name
for f in os.listdir('.'):
    if file_ext(f) == '.sln':
        os.rename(f,app_name + '.sln')


#Changing clean arch layer directory names and csproj names
for layer in os.listdir(project_dir_src):
    layer_path = project_dir_src + layer
    for layer_f in os.listdir(layer_path):
        if file_ext(layer_f) == '.csproj':
            os.rename(layer_path +'/'+ layer_f, layer_path + '/' +app_name+'.'+layer+ '.csproj')
    os.rename(layer_path, project_dir_src + app_name+'.'+layer)


#Recuresively changing all solution name references for all files
change_files_rec(project_dir)

print('Application created at: '+dest)
print("Enjoy codeing")

#TODO: Change the algo to dynamicly change the folders and file names to adapt to all posible tempaltes


