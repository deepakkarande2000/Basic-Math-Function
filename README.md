# Project README

## Overview

This project includes:
- Two .NET Core applications
- One Angular application

Follow the instructions below to run these applications locally.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) (for .NET Core applications)
- [Node.js](https://nodejs.org/) (includes npm for Angular application)
- [Angular CLI](https://angular.io/cli) (for serving Angular application)

## Running the Applications

### 1. Running .NET Core Application 1 (Port 4001)

1. Open a command line interface (CLI).
2. Navigate to the directory containing the first .NET Core application.

   cd path/to/your/dotnet-core-app1

3. Restore dependencies.
	dotnet restore
4. Build the application.
	dotnet build
5. Run the application on port 4001.
	dotnet run --urls http://localhost:4001
_________________________________________________________________________________
### 2. Running .NET Core Application 2 (Port 4002)

1. Open a new command line interface (CLI) or terminal window.

2. Navigate to the directory containing the second .NET Core application.	

cd path/to/your/dotnet-core-app2

3. Restore dependencies.
 	dotnet restore
4. Build the application.
	dotnet build
5. Run the application on port 4002.
	dotnet run --urls http://localhost:4002
_________________________________________________________________________

###3. Running the Angular Application (Port 4200)

1. Open another command line interface (CLI) or terminal window.

2. Navigate to the directory containing the Angular application.
	cd path/to/your/angular-app

3. Install dependencies if they are not already installed.
	npm install

4. Serve the Angular application on port 4200.

ng serve --port 4200


Ensure that each application is running in its respective terminal window to avoid port conflicts.







