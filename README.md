RACEDAY API 

In this part 2 version of the project the endpoints created in part 1 are now implemented into the project to be able to formulate and connect the project to the database so both the endpoints and sql server can work together.

The project consists of classes, controllers and unit tests 
the classes allow the endpoints to be implemented while also restricting user access on specific roles of the application which also links to the use of the sql server being implemented including the RaceDayContext file whhich allows the correct imports to be utilised throughout the project.

-RaceDayAPI
-raceDay.db

-Class
   -Category
   -Organiser
   -Participant
   -raceEvent
   -registration
   -result
-Controllers
    -categoryController
    -OrganiserController
    -ParticipantController
    -raceEventController
    -registrationController
    -resultController
    
-Data
  -RaceDayContext

-UnitTesting
  -OrganiserTest
  -ParticipantTest
  -raceEventTest
  -RegistrationTest