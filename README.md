# MongoDB

The project includes an MVC application that manage CRUD operation, and a Console Program that show, after a query, the first 5 elements in Database and makes the title of the first element in uppercase.
There are also the guide for a quick installation of MongoDb(MongoDB_HowToStart) and the collection to import on Db. 
The name of db is BookMVC, so if you change the name of database, take care to change the name also into the project.

Part 1 – Install MongoDB
1.	Go to http://www.mongodb.org/ (not http://www.mongodb.com) and download the latest version of MongoDB. Unzip it in an executable directory – typically: c:\mongodb\program
2.	To make working with MongoDB easier, add this folder to your path. Need some help? Look here.

3.	Create a directory where mongodb should store its data files, for example: C:\MongoDB\mongodata
4.	Create a directory where mongodb should store its log files, for example: C:\ MongoDB\log
5.	Our goal is to install MongoDB as a Windows Service. But it is much easier to debug setup issues in the command prompt. Try starting mongod.exe in the command prompt using this command (altered for an path changes you chose):

C:\Programmi\MongoDb\Server\3.0\bin\mongod.exe   –dbpath C:\mongodata
(depending by the path where Mongo is installed)

6.	Then start the client, starting mongo.exe in the command prompt using:
 
C:\Programmi\MongoDb\Server\3.0\bin\mongo.exe 

7. To install MongoDb as Service for Windows, follow this guide: 
  "Configure a Windows Service for MongoDB - https://docs.mongodb.org/master/tutorial/install-mongodb-on-windows/ "
