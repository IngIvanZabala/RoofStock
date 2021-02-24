
Please clone the following github public repo: https://github.com/IngIvanZabala/RoofStock

* The repo contains two folders RoofStockAssestment for the API and RoofStockUI for the UI
* Tha folder RoofStockAssestment contains the API project, and the Sql script named "RoofStockPropertiesDB.sql"
* The Script file, should be run on sql server. Open it and run it.
* The folder RoofStockAssestment contains the backend solution, Once you run the script you'll be able to run the solution
  It should runs for the http port 50638, the connection string was configured like this: Server=(LocalDb)\\MSSQLLocalDB;Database=Properties
  If you don't have the LocalDb Instance, you should change the connection string on the appsettings.josn and Common/Entities/PropertiesContext
  And It sould works!

* The folder RoofStockUI contains the frontend solution, you can open the folder with VS Code, Atom, or
  your preferred Front end text editor. You have to had installed node js on your machine. 
  To run the project, go open a console and type npm install and press enter key. When it finishes, type the command ng s -o
  if the backend Http port has changed, you should modify the environment.ts file contained on src/environments and update
  the key urlService, whith the current http port.

That's it. 
Enjoy the code :)

Any question or comment, please let me know!

email: mauricio2807@hotmail.com	
Phone: +57 302 262 5750
