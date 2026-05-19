# Microservices Architecture with .NET 8

This project demonstrates a microservices-based architecture using ASP.NET Core .NET 8.

## Features

- JWT Authentication
- API Gateway using YARP / Ocelot
- RabbitMQ Messaging
- Saga Choreography Pattern
- Order Management
- Inventory Management

## Services

- UserService
- AuthService
- OrderService
- InventoryService
- ProductService
- ApiGateway
- Shared Contracts

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / PostgreSQL
- RabbitMQ
- YARP / Ocelot

## Architecture

Client requests first go through the API Gateway.
Microservices communicate asynchronously using RabbitMQ events.

## How to Run

1. Clone the repository

```bash
git clone YOUR_REPO_LINK
```

2. Configure database connection strings

3. Run RabbitMQ

4. Start all microservices

## Future Improvements

- Docker support
- Redis caching
- Kubernetes deployment
- Payment Service
