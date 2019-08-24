# Toop Project
Shows a page with a number of paragraphs of text, with a READ MORE button. • Clicking the READ MORE button invites the user to register to read more. • The registration only needs to be an email address and password. • Upon registration, with email validation, the user can now view the rest of the text that was previously hidden. • An alternative sign-in button allows someone to login to view that extra text too, if previously registered.

# Help to Run Project
There are two projects
- [Front Project](https://github.com/yMahmodui/CMSFront)
- - install node.js
- - install angular
```
        npm install -g @angular/cli
```
- - install ts-md5
```
        npm install ts-md5 --save
```
- - run project
```
        ng serve --open
```

- [Current Project](https://github.com/yMahmodui/CMSProject)
- - open MyMVCApplication.sln
- - open PowerShell in visual studio and select Models solution then write following commands
```
        Enable-Migration
        Add-Migration InitialCreate
        Update-Database
```
- - run project
Now you can test the project and enjoy it!

Connect Angular project to backend in order to fetch post 
To read more about post, Registration/Login is necessary 
List of users 

Visual Studio
Node
Angular
Visual Studio Code

# Architecture
- Backend(Services)---Different Layers--DAL, Models, View Models, Dtx, Test and main project(Controller & Actions) 
DAL-Use of Repository and Unit of work
Entity Frame work code first

- Frontend----Angular--Post Module, Components, Services, Interceptors(JWT)

# Data follow in this project
![image](https://user-images.githubusercontent.com/23130739/63633162-c1103f80-c658-11e9-86be-255df206927d.png)