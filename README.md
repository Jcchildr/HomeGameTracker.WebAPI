# HomeGameTracker.WebAPI
## Mission Statement
Our team has created an electronic storage and search system for peoples’ collections of games. While it sounds easy enough to just keep track of your xbox collection, our API is designed with many types of games in mind, from solitaire and croquet to Monopoly or GTA (on several platforms). Games will be represented by tailored objects, stored in repositories with unique fields and methods that pertain to the specific type of game being stored. Then, once you’ve gotten your games added, unleash the power of our analytical API. Search by storage area, type of console, whether the game is a gambling game… the possibilities are endless*. If you’ve ever wondered what card game to get out for 5 ten year olds, or what classic board game pairs well with muder dinner theater, look no further!


*the possibilities are finite

## Database

Our database consists of four distinct game classes that inherit from a base Game class consisting of properties that all games have in common. The Game class is also linked to the StorageArea via a Foreign Key relationship of one to many. This allows us to share information between the StorageArea class and all the inherited game classes.

### Main Classes 

Game[Key]

StorageArea[Foreign Key]

[Game Classes Using Inheritance]

VideoGame : Game

CardGame : Game

BoardGame : Game

YardGame : Game

## EndPoints/Usage 

Every GameType has all the basic CRUD and Endpoints (POST, GET, PUT, DELETE, and GET by Id). 
There are a few special GET elements that allow the user to access select content in the Database. 

The Storage Area has several of these special GET requests including showing the count of games in a certain storage area, ability to search for storage areas based on the game type associated with it, and the ability to view the specific games in a single storage area. 

## License
Team TNG
E50QA
