# LotteryApp

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

