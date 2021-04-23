# Smart AC (Proof of Concept)
### Prototype application written by [Brandon Alexander](brandonalexander.dev) for [Theorem, LLC](https://www.theorem.co/)

## Overview
Smart AC is a backend system designed to integrate with remote air conditioning units. It is comprised of three main services
* Registration - handles authentication of remote AC units,provide tokens for the web API, and maintains state of registered devices
* SensorReadingDataHub - provides API endpoints for air conditioners to report their data readings and supplies them to other services
* Administration - generates alerts on reported data and allows admins to resolve them

All three services are hosted in an ASP.net app, which also hosts an administration web portal. This web app is the main is the entryway to the application (see "Running the app" below).


## Running the app
### Prerequisites
* .NET SDK 5
### Steps
* Clone the repo and navigate to the Web project in the repo
* Set the *AppSettings__EncryptionKey* app setting. You can do this a few ways
    * [dotnet User secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)
        * when using this method, replace the "`__`" in the key with an "`:`" i.e. *AppSettings:EncryptionKey*
    * [Environment variables](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#environment-variables)
    * See [the ASP.NET docs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#environment-variables) for more info
* Run `dotnet build`

## Notes
Since this is a prototype application, there are some aspects that have been pared down or simulated.
* Databases is SQLite, which has limitations inherent to it's in-process architecture (e.g. speed)
* User sources are simulated very loosely
    * In the administration portal, any username/password will grant access
    * In the registration service, device serial numbers and secrets are hard coded on a file on disk
* All separate services are hosted by the same ASP.Net web application for ease of deployment and configuration
* There are no data verification or formatting restrictions beyond that of their underlying data type
* Common application functions such as error recovery, logging, and monitoring have been foregone
* The application is standalone and is not supported by other services such as a reverse proxy or container orchestrator
* There is no defined CI\CD process


made by [Brandon Alexander](brandonalexander.dev)