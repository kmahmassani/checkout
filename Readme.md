# Payment Gateway

## Introduction

This is an API for a basic Credit Card processing gateway.  The gateway allows a merchant:

-  To process a payment
-  To retrieve details of a previously made payment

I have to tried to follow the style of Checkout.com's existing API as much as possible, while removing details out of the scope of this assignment.

## Architecture

This repository contains:
- The payment gateway, written in .Net Core
- Postgres DB for storing payments
- A mock Bank API for simulating a real bank

## How to run

### Prerequisites

- Docker

Open a terminal/cmd window in the main directory and run

```
docker-compose up
```

The Payment Gateway can be found at http://localhost:5000/swagger

The mock Bank API will be at http://localhost:5001/swagger

You may connect to the Postgres DB at localhost:5001 if you wish to explore the data.

## Notes

- Unit tests have been implemented for some basic scenarios, just to show style of tests to be implemented
- Solution has been containerized for ease of use
- Assumption has been made that full card details are not saved by payment gateway
- Dapper has been used vs EF Core, on the assumption that a full ORM would not be needed, and a more performant option would be preferred

## Further points

With further time the next steps would be

- Add check to authorization header value, by calling an Auth service
- Add unit tests execution to docker build
- Add Postman tests for E2E testing (via newman scripts)
- Encryption
- Logging via FluentD