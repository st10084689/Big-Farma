# Big-Farma

project name: Big Farma

student Name: Jamie Theo Junk

student Number: st10084689

student email: st1008468@vcconnect.edu

module:prog7311_poe


Date Created : 24 may 2023

target framework: 7.0

#plugins


   Microsoft.AspNetCore.Identity.EntityFrameworkCore Version="7.0.5" 
   Microsoft.AspNetCore.Identity.UI Version="7.0.5"
   Microsoft.EntityFrameworkCore Version="7.0.5" 
   Microsoft.EntityFrameworkCore.SqlServer Version="7.0.5" 
   Microsoft.EntityFrameworkCore.Tools Version="7.0.5"
   Microsoft.VisualStudio.Web.CodeGeneration.Design Version="7.0.6" 




#Descripion
Big Farma is a web application designed for managing products and users in a farming organization. It provides features for storing product information in a database, separating farmers and employees with authorization, and granting admin/employee access to view and modify product data.

## Features

- Stores product information in a database.
- Separates farmers and employees with authentication and authorization.
- Admin/employee roles can view and modify all product data.
- employee can add new admins/employees to the system.
-sort the products list by date and price

## Installation

To run the Big Farma project locally, follow these steps:

1. Ensure you have the following prerequisites installed:
   - .NET SDK (version 7.0 or later)
   - SQL Server (or any other supported database provider)

2. Clone the repository or download the project files.



4. Run the following command to restore the project dependencies:

5. Configure the database connection string:
- Open the `appsettings.json` file.
- Update the `ConnectionStrings` section with your database connection details.(if neccessary, the application should work with changing anything)

6. Apply database migrations: if necessary( application automatically does it)

7. Start the application:

8. Open your web browser and visit `http://localhost:5000` to access the Big Farma application.

	##FAQ

1.WILL IT WORK ON ANY DEVICE:
  It will work on any device, the migration and database will run automatically if the user runs the compiles the application.

2.DOES THE AUTHENTICATION WORK:
  the application allows only authoized users to access certain information.




## License

[MIT License](LICENSE).

#####################################USER ACCOUNTS##############################################
***********admin/Employee account*********
Email: admin@gmail.com
password: Admin123!

***********Customer/Farmer*********
Email: farmer@gmail.com
password: Farmer123!

#Github

https://github.com/st10084689/Big-Farma-Vm

#Azure

https://bigfarma.azurewebsites.net





