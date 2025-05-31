# Board Game Ledger
##  Project Overview

This project is a REST server application built with .NET that allows users to track how often they play specific board games. It highlights which games are played most frequently and which have been forgotten over time.

Additionally, the system is planned to support statistics such as:
- Which board games of generes of board games user plays the most
- What place the user usually achieves in each game
- The average score the user earns across sessions
- Which players user plays with most often

###  Technologies

- **ASP.NET Core 8**
- **Entity Framework Core**
- **MySQL**
- **ASP.NET Core Identity with JWT authentication**

###  Authentication

The project uses **ASP.NET Core Identity with JWT-based authentication**. After logging in, each user has access to their own private data scope and can:
- Add board games
- Register their own list of players
- Record sessions for specific games

Each entity (games, players, sessions) is, as of now, tied to the authenticated user.

##  Project Status

This project is still under development.

Core CRUD functionalites for board games, players, and sessions are implemented.
Authentication and authorization is implemented.
However, **statistics endpoints are not yet developed**.

Deployment and environment setup are currently not finalized.

## How to launch it
 - install .NET 8 or newer.
 - use some sort of MySQL server (I used the one from XAMPP for development, as I already had it installed).
 - Navigate to the Board-Game-Ledger/Board-Game-Ledger/ folder in the command line (the folder structure is like this because the project was created in Visual Studio 2022).
 - use dotnet build.
 - use dotnet ef database update.
 - use dotnet watch run to launch the app in development mode, which will allow you to test the endpoints through Swagger.

### Features yet to be implemented:
- Statistics endpoints related to boardgame and players
- Improved validation
- Some sort of interface for the user (mobile or web app, don't know yet)
- ~~Storing more data about games, for example which player played which faction~~
- Overall improving the application after reciving feedback from test users (my friends who also like to play boardgames)
- Automated tests
- Code refactoring
