# LotteryApp

## Introduction

This is a lottery application developed using Xamarin.Android. The app allows users to view lottery draws, generate lottery tickets, and see the details of each draw. The business logic is handled in a shared library (Lottery.Shared) that can be reused across different projects.

## Prerequisites
-Visual Studio 2022
-Xamarin.Android
-.NET Framework 4.7.2 (for test project compatibility)

## Setup Instructions

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Ensure you have the required Android SDKs installed.
4. Build and run the application.

## Technologies Used

- Xamarin.Android
- C#
- Newtonsoft.Json for JSON parsing
- NUnit for unit testing

## Features

- Load and parse lottery draw data from a JSON file.
- Display a list of lottery draws.
- View detailed information for each draw.

## Testing

Unit tests are located in the `Tests` project. To run the tests:

1. Open the solution in Visual Studio.
2. Build the solution.
3. Run the tests using the Test Explorer.

## Challenges and Learning

- COMPATIBILTY ISSUES!!!!
- Xamarin.Android out of support
- Visual Studio had no default unit test project for xamarin android even when there claims online to the contrary
- found a really nice blog :https://dgatto.com/posts/2020/12/droid-nunit-template/
- got it working but it had its own compatibility issues
- first Decoupled android file reader to integrate a file mock service so it could be easier to test
- ran into more compatibility issues so I further decoupled the process to include a shared project using . net 	standard that was compatible with monoandroid13 and .net 4.8 for the Nunit Packages

## Future Enhancements

- Implement offline caching using SQLite or SharedPreferences.
- Improve UI/UX with custom animations and components.

## Project Structure
LotteryApp/
├── Lottery/
│   ├── Adapters/
│   │   └── DrawListAdapter.cs
│   ├── Activities/
│   │   ├── DrawDetailActivity.cs
│   │   ├── MainActivity.cs
│   │   └── TicketActivity.cs
│   ├── Fragments/
│   │   └── DrawDetailFragment.cs
│   ├── Resources/
│   │   ├── drawable/
│   │   │   ├── logo.png
│   │   │   └── circular_shape.xml
│   │   ├── layout/
│   │   │   ├── activity_main.xml
│   │   │   ├── DrawDetailView.xml --TicketView.xml
│   │   │   ├── DrawListView.xml
│   │   │   └── Fragment_DrawDetail.xml
│   │   ├── values/
│   │   │   ├── colors.xml
│   │   │   └── styles.xml
│   ├── Services/
│   │   └── FileService.cs
│   ├── Lottery.csproj
├── Lottery.Shared/
│   ├── Services/
│   │   ├── DataStore.cs
│   │   ├── DatabaseService.cs
│   │   ├── IFileService.cs
│   │   └── IDatabaseService.cs
│   ├── Models/
│   │   └── Draw.cs --DrawResponse.cs
│   └── Lottery.Shared.csproj
└── LotteryTestNet/
    ├── Services/
    │   └── MockDatabaseService.cs
    ├── DataServiceTests.cs
    └── LotteryTestNet.csproj

