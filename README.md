##  Attendance Application

Note: For ASP.NET MVC 5 , EntityFramework.6.2.0 

 

## Installation 


* 1- Run SQL Server and create empty database. 
* 2- Run Visual Studio 2017.
* 3- Open Web.config file and replace the connection strings name it DefaultConnection with your new database  and your sqlserver user with my sa and password with my password and in appSettings you can change default user email name => AdminEmail and default user password => Password.
* 4- Run Package Manager Console from tools => NuGet Package Manager => Package Manager Console.  
* 5- Run this command line 
    1- enable-migrations 
	2- add-migration  InitialCreate 
	3- update-database  
* 6- Now at the end Run Ctrl + F5
* 7- Login as default user  :
    username: admin@admin.com
	password: 123
    again you can change it from  Web.config file in appSettings you can change default user email name => AdminEmail and default user password => Password.
	



## Using

we have 2 type of user 
1- Admin : can see all Attendance from Attendance in main menu and can filter by user and date and can create Employees and admin users from main menu Employees
2- Employees : just can sign in the Attendance and see it Attendance from My Attendance in main menu 


  