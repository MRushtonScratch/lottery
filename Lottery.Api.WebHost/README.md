# LOTTERY
## Whats in the repository
This repository contains a .Net Core 1.0.0 REST API and basic angular 1.5 client.  The API is documented using swagger, available from the url /swagger/ui/index.html 
and describes the resources:-

POST /api/lottery/draw
GET /api/lottery/draw/{drawDate}
PUT /api/Lottery/draw/{name}/winningNumbers

## Repository Structure
For the purposes of this POC the project is structured into a single project and logically broken down into

Controllers - Defines the Lottery API
Domain - The Core domain for a Lottery is modelled here and can be extended to ensure that core rules are adhered too.
Interfaces - The interfaces as used by the .Net Core DI container. 
Repositories - Data Access repositories with a simple InMemory implementation, this could easily be replaced to use a NoSql or SQL provider. 
Services - Services used to orchestrate between controller and repositories.
wwwroot - contains the client for a basic Angular 1.5 application.

## Backlog of further Improvements
The following are some further changes that could be implemented.

### API
- Version the API
- Set the Media Type for the API
- Use a resource Id instead of name when PUTting the winning numbers
- Create an HttpClient that consumes the API leading to the ability to run Integration Tests

### Repository Structure
- Decouple the layers of the WebHost into separate projects

### Services
- Add caching of GET requests
- Split services into targetted CQS Commands and Queries utilising contracts


### Testing
- Add unit test coverage of core rules within the Domain
- Add integration tests using an HttpClient that wraps the API

### Web client
- Implement client-side build process that would enable bundling, minification of JavaScript
- Split UI into a SPA consisting of routes
- UX and Styling






 