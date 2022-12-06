# TournamentDistributionHexa
## The need
As the vice-president of a board game club, I need to organize a tournament for my fellow comrades and I. We have voted for the most wanted games we wanted to challenge ourselves with and 10 of them have been elected. So, the 12 players must play these 10 games for 3 months. I need a program to distribute the players in pools where the pools are not always the same for each game. Each game cannot have more than 4 players.

For example :

BoardGame1 - Match1 - Player1 + Player2 + Player3

BoardGame1 - Match2 - Player4 + Player5 + Player6

BoardGame1 - Match3 - Player7 + Player8 + Player9

BoardGame1 - Match4 - Player10 + Player11 + Player12

[...]    

BoardGame10 - Match1 - Player1 + Player11 + Player9

BoardGame10 - Match2 - Player4 + Player2 + Player12

BoardGame10 - Match3 - Player7 + Player5 + Player3

BoardGame10 - Match4 - Player10 + Player8 + Player6

## The objectives
In this repository, I challenge myself to implement the program with practices or technologies I do not master like :

- Test-Driven Development, 

- Hexagonal architecture,

- NCrunch (background automated unit testing VS extension).

## Prerequisites
If you want to build the project, you may need to create the database. The schema script is present in TournamentDistributionHexa.Infrastructure/SQL Scripts.
