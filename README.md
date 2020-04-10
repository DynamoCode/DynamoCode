# DynamoCode
[![Build Status](https://dev.azure.com/dynamocode/DynamoCode/_apis/build/status/DynamoCode.DynamoCode?branchName=master)](https://dev.azure.com/dynamocode/DynamoCode/_build/latest?definitionId=2&branchName=master)
[![Deployment Status](https://vsrm.dev.azure.com/dynamocode/_apis/public/Release/badge/7618c063-005f-45b5-b90e-149ebe322e01/1/2)](https://vsrm.dev.azure.com/dynamocode/_apis/public/Release/badge/7618c063-005f-45b5-b90e-149ebe322e01/1/2)

This repository contains a base architecture to build on top when creating a new .NET project. This implementation is targeting netstandard2.0 for more compatibility.

We have chosen Domain Driven Design to create a base architecture implementation that organises and helps to reduce the boiler plate code.

We also provide an opinionated yet flexible way to structure an application following good practices and design concepts.

* [Quick overview of Domain Driven Design](docs/domain-driven-design.md)
* [Our vision of Layered Architecture](docs/layered-architecture.md)
* [Our Samples repository](https://github.com/DynamoCode/DynamoCode.Samples)

## Application structure

There countless ways to structure an application, but we see four big groups of components:

* Domain
* Application
* Infrastructure 
* Presentation

Each of those can be sub divided depending on the specific project size and requirements.

## Getting Started

Create projects for Domain, Infrastructure and Application.

Add references to the nuget packages for each layer.

* DynamoCode.Domain
* DynamoCode.Infrastructure
* DynamoCode.Application (not available yet)

[Using dotnet cli to get started](docs/dotnet-cli-create-projects.md)

## Creating Entities

Entities are one of the pillars of DDD, they are domain concepts that have a unique identity in the problem domain. We provide base classes and interfaces to help in this area.

[Tree ways to create entities](docs/create-entity.md)

## Creating Repositories

Repositories are a fundamental part of the infrastructural concerns as they mediate between the domain model and the data model. We provide base classes and interfaces to help in this area. 

[Creating repositories](docs/create-repository.md)