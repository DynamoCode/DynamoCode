# DynamoCode
[![Build Status](https://dev.azure.com/dynamocode/DynamoCode/_apis/build/status/DynamoCode.DynamoCode?branchName=master)](https://dev.azure.com/dynamocode/DynamoCode/_build/latest?definitionId=2&branchName=master)

This repository contains a base architecture to build on top when creating a new .NET project. This implementation is targeting netstandard2.0 for more compatibility.

We have chosen Domain Driven Design to create a base architecture implementation that organises and helps to reduce the boiler plate code.

We also provide an opinionated yet flexible way to structure an application following good practices and design concepts.

* [Quick overview of Domain Driven Design](domain-driven-design.md)
* [Our vision of Layered Architecture](layered-architecture.md)

# Application structure

There countless ways to structure an application, but we see four big groups of components:

* Domain
* Application
* Infrastructure 
* Presentation

Each of those can be sub divided depending on the specific project size and requirements.