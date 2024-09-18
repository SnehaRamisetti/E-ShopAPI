# EShopAPI

EShopAPI is a .NET 7 Web API for managing products, orders, and customer details. It includes user authentication and authorization using JWT tokens.

## Features

   - Product, Order, and Customer Management
   - User Registration and Login with JWT Tokens
   - Secure API Endpoints with JWT Authorization
     
## Technologies Used
   - ASP.NET Core 7
   - Entity Framework Core
   - SQL Server
   - JWT Authentication
   - Dependency Injection
## Getting Started
## Prerequisites
   - .NET 7 SDK
   - SQL Server
## Authentication
   - Register: POST /api/auth/register
   - Login: POST /api/auth/login (returns a JWT token)
Use the token in the Authorization header to access secure endpoints.
## API Endpoints
   - Products: GET /api/products
   - Orders: GET /api/orders
   - Customers: GET /api/customers
## Conclusion
EshopAPI provides a simple and effective solution for managing e-commerce operations with secure JWT-based authentication.
