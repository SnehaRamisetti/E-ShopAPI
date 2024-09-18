##eShopAPI
   eShopAPI is a .NET 7 Web API for managing products, orders, and customer details. It includes user authentication and authorization using JWT tokens.
##Features
   Product, Order, and Customer Management
   User Registration and Login with JWT Tokens
   Secure API Endpoints with JWT Authorization
##Technologies
   ASP.NET Core 7
   Entity Framework Core
   SQL Server
   JWT Authentication
   Dependency Injection
##Getting Started
##Prerequisites
.NET 7 SDK
SQL Server
Installation
Clone the repository:
bash
Copy code
git clone https://github.com/yourusername/eshopapi.git
cd eshopapi
Update the appsettings.json with your SQL Server connection string.
Apply database migrations:
bash
Copy code
dotnet ef database update
Run the API:
bash
Copy code
dotnet run
Authentication
Register: POST /api/auth/register
Login: POST /api/auth/login (returns a JWT token)
Use the token in the Authorization header to access secure endpoints.
API Endpoints
Products: GET /api/products
Orders: GET /api/orders
Customers: GET /api/customers
