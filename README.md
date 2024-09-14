# ProjectHub
The ProjectHub is an API application for a personal management application designed to handle general projects.

## Project Structure
The structure of the application
### API
The API layer is responsible for exposing the application's functionality to external clients.

### application
The Application layer contains the use cases and business logic of the application.

### Domain
The Domain layer represents the core of the application, containing the business logic and rules. It is independent of any external systems and should have no dependencies on the Application, Api, or Infrastructure layers.

### Infrastructure
The Infrastructure layer contains implementation details related to external systems and technologies. It provides the necessary implementations to fulfull the requirements of the Application and Domain layers.

### Tests
The Tests layer includes various tests to ensure the quality and correctness of the application. This layer can be further subdivived based on the types of tests.

### Libraries
 - JWT
 - Elastic Search
 - Entity Framework
 - SSO (Single Sign On)
 
### Entities
 - Tag
 - Comment
 - ApiUser
 - Space
   - Section
     - Epic
	   - Feature
	     - Activity
	   - Bug
	  
### Ideas
  - Add Next and Prev to the endpoints
  - Add Query options to include details
  - Add Query options to filter
  
### Todos
  - Create Sprint Entity, figure out how it is related
  - Clean up dtos (DONE)
  - Figure out which fields are required and which are not
  - Entity properties "private set" how to handle (DONE)
  - Add Error Handling
  - Add Validators
  - Add Middlewares
  - Add Exceptions
  - Change name from PersonalHub to ProjectHub (DONE)