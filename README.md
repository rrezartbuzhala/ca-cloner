# ca-cloner

1. Change the destination directory in the python script (dir_dest)
2. Run the script providing the template name as the first parameter and the solution name as the second parameter
 `python dotnet.py clean-arch TestSolutionName`
3. Change the `ConnectionStrings:ApplicationDatabase` and the `Authentication:Secret` in "src/presentation/PublicApi/appsettings.(Development).json" 
4. Run the app

Feel free to change the "clean-arch" template for your likings or add other Templates (contribute)
