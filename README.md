# Clash Royale Manager

This college project aims to give a website to register activity about players, cards, clans, wars between clans... in the game [**Clash Royale**](https://play.google.com/store/apps/details?id=com.supercell.clashroyale&hl=en_US).

**Disclaimer:** This is not a commercial product but a *Software Engineering* project in the *Computer Science Degree* (Mathematics and Computer Science Faculty, MATCOM, Havana's University). The **Clash Royale** name is being used with educational and non commercial purposes only.

## Requirements

To run this project it is required a working installation of [DotNet Core 8.x.x](https://dotnet.microsoft.com/en-us/download/dotnet/8.0), any previous version will not be compatible and in the future DotNet Core 9+ will probably not be compatible either.

The Api uses a [Postgres](https://www.postgresql.org/download/) database (v14+) so it will be required. *Note*: you may have to update the connection string inside the [`appsettings.json`](./api/src/ClashRoyaleManager.Api/appsettings.json) file to match your local installation.

The frontend is made in [Vue](https://vuejs.org/) so a [Node.js](https://nodejs.org/en) installation will be needed (version still pending).

For easy use, we use [Task](https://taskfile.dev/) a task runner/build tool that aims to be simpler and easier to use than, for example, GNU Make. To install task view [this](https://taskfile.dev/installation/#scoop) for Windows and [this](https://taskfile.dev/installation/#scoop) for Linux.

## Task commands

This commands are in essence a *how-to* guide to this project. Running each one will do what is described down below:

1) `task api:restore`: install dependencies and NuGet packages for the Api

2) `task api:run`: runs the api in development mode