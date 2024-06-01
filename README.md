# LibraryProjectAPI

Web Api for managing data about the library, books, authors and users' book rentals.

## Description

Project contains an authentication system using JWT tokens. The user can be either a librarian or an ordinary user. There is one admin seeded in the database. As logged in admin creates librarians, while librarians create users. Thus, authorization is implemented

Author and book entities and their CRUD operations are created. The functionality of renting books to users with restrictions on whether there are enough copies or not has been implemented.

Pagination, as well as filter and sort, are implemented on the GetAllBooks endpoint.

The user can change his personal information and can see his book rental history. Also, the user can leave a review for any book.

## Instructions

When you download the project, open the Project Manager Console and type the command "add-migration (migration name)". After the migration is created, type "update-database" command for upating the database.

## Built with

- ASP.NET Core
- ASP.NET Web Api
- Microsoft SQL Server Managment Studio
- Class Libraries
- Entity Framework (EF) Core
- Repository Pattern
- SOLID
- Dependency Injection
- JSON Web Token (JWT)
- FluentValidation
- AutoMapper
- Postman
- Swagger UI

# Author

- GitHub - [@MilosMoskic](https://github.com/MilosMoskic)
- LinkedIn - [@milos_moskic](https://www.linkedin.com/in/milosmoskic/)
