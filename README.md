It is important to note that the Application will not run unless both the RugbyDataApi and MvcRugby application are both running. The MvcRugby application relies on the API to obtain and render data on the UI.

The MvcRugby section of the Application will not work, and no views will render on the UI unless the RugbyDataApi is set up and running beforehand.   

To set up the web application, please follow these steps:

1.	Extract all folders / files from the zipped folder provided and save in the chosen location on your local machine. 

API - RugbyDataApi:

2.	In your chosen code editor, open a command terminal and navigate to the “ProductsApi” folder.:

3.	To setup and build the project, enter the command: ‘dotnet build’.

4.	To add migration scripts, enter the command: ‘dotnet ef migrations add AddRugbyData’.

5.	To update the database, enter the command: ‘dotnet ef database update’’

6.	To run the application, enter the command: ‘dotnet run’, or ‘dotnet watch’.

**Steps 1 – 6 are required to operate the MvcRugby Application**

Main Application - MvcRugby:

7.	In your chosen code editor, open a second command terminal and navigate to the “MvcRugby” directory.

8.	To setup and build the project, enter the command: ‘dotnet build’.

9.	To run the application, enter the command: ‘dotnet run’, or ‘dotnet watch’.
