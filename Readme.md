# Payment Gateway
## Introduction
This is an API for a basic Credit Card processing gateway.  The gateway allows a merchant:
-  To process a payment
-  To retrieve details of a previously made payment

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