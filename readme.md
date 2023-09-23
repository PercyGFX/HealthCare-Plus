#  C# Hospital Management System

### Features

- Two user roles as admin and staff
- secured logins with md5 encryptions
- staff members can be registered 
- admin can manage patients, doctors, room details, resources & generate various reports
- admin can create bills for each patient and accpet payments (cash)
- staff can add/reschedule/cancel appoinments
- staff can allocate rooms to patients
- staff can add medications to patients

------------

### Tech Stack
- Visual Studio 2022
- XAMPP to run mysql server
- MySql.Data, EPPlus, PDFshap nuget packages


------------

### How to setup
- Import "healthcare.sql" file to your mysql server
- Edit mysql connection details on "services/Database.cs"
- Run the project


------------

### Sample login data
*Admin
`Username : admin`*
`Password: 12345678`


------------


*Staff
`Username : user`*
`Password: 12345678`



###Images



![](https://raw.githubusercontent.com/PercyGFX/HealthCare-Plus/main/images/1.png)

> Login screen.

![](https://raw.githubusercontent.com/PercyGFX/HealthCare-Plus/main/images/2.png)

> Staff registration.

![](https://raw.githubusercontent.com/PercyGFX/HealthCare-Plus/main/images/3.png)

> Admin dashboard.

![](https://raw.githubusercontent.com/PercyGFX/HealthCare-Plus/main/images/4.png)

> Admin Dashboard patients.

![](https://raw.githubusercontent.com/PercyGFX/HealthCare-Plus/main/images/5.png)

> Add patient.

###End
