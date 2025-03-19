# ProductManagement
Tools and Framewok Required for Project
- Microsoft Visual Studio 2022
- Microsoft SQL Server 2022
- .Net 9

After downloading the project, Right-click on Solution and go to Properties.
<br/>
Set Product.WebApi as StartUp Project
<br/>
<br/>
![image](https://github.com/user-attachments/assets/fe509f78-7f39-4bdf-824e-caa8d3cd60d8)
<br/>
<br/>
Select IIS Express as Debug Target
<br/>
<br/>
![image](https://github.com/user-attachments/assets/19d2f11c-fa59-4929-add2-37095b5b16b6)
<br/>
<br/>
Update sql server connection string with your local SQL server setting in appsettings.json of Product.WebApi
<br/>
<br/>
![image](https://github.com/user-attachments/assets/a34daeec-0aeb-4b14-97f4-8a069c26dc91)
<br/>
<br/>
Run the solution and Api with Scalar UI will launch.
<br/>
EntityFramework is used for database creation.
<br/>
After Api is launched successfully, database named ProductDb should be created in your local server.
<br/>
<br/>
![image](https://github.com/user-attachments/assets/ce3880c5-5a30-4b77-9638-ede29fc61ee7)
<br/>
<br/>
Run the script file StoredProcedure.sql(located under Infrastructure/Product.Persistence/Scripts) in Database
<br/>
<br/>
![image](https://github.com/user-attachments/assets/32096828-55a8-4494-8fd6-b663f0e02e38)
<br/>
Stop the application and right-clik on Solution.
<br/>
Go to properties and Select Multiple Startup Projects:
<br/>
Set Product.WebApi, Product.WebApp as Startup projects.
<br/>
<br/>
![image](https://github.com/user-attachments/assets/992a4f35-a3d1-4e32-acb6-e855466b4e7f)
<br/>
<br/>
Project Order must be as shown in Figure.
<br/>
Select IIS Express as Debug Target for All.
<br/>
<br/>
Update the log file path for Product.WebApi and Product.WebApp according to your PC.
<br/>
<br/>
![image](https://github.com/user-attachments/assets/64ed960d-5536-41ae-9137-ab71eb0f1c23)
<br/>
<br/>
Run the solution and two browser pages will launch.
<br/>
Api with Scalar UI and Website for Product CRUD.
Now Project is ready for testing.
<br/>
<br/>
![image](https://github.com/user-attachments/assets/4ad3f4ae-9ce6-4222-b3c1-f2a65ec491d6)

