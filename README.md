# Board Game Ledger
##  Project Overview

The main goal of this project is to allow users to track how often they play specific board games and highlight which games are played most frequently and which have been forgotten over time.

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

###  Project Status

This project is still under development.

Core CRUD functionality for board games, players, and sessions is implemented.  
However, **statistics endpoints are not yet developed**.

Deployment and environment setup are currently not finalized.
