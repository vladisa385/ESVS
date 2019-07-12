# ESVS

This system has been developed for working with existing medical catalogs. You can also create, modify and add fields.
![](https://pp.userapi.com/c857632/v857632026/145e8/-WbsZrNpPGY.jpg) 
![](https://pp.userapi.com/c857632/v857632026/145fc/8SH0hCXUaJo.jpg)
## Getting Started

Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017+](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

### Installing

Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Next, within the `Northwind.WebUI\ClientApp` directory, launch the front end by running:
     ```
     npm start
     ```
  5. Once the front end has started, within the `Northwind.WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [http://localhost:52468/](http://localhost:51718/) in your browser to view the Web UI
  
  6. Launch [http://localhost:52468/api](http://localhost:51718/api) in your browser to view the API

## Built With

* .NET Core 2.2
* ASP.NET Core 2.2
* Entity Framework Core 2.2

## Authors

* **Vladislav Konyukhov** - (https://github.com/vladisa385)
* **Kirill Yashenkov** - (https://github.com/MrMagic24)
* **Vitalii Domantsevich** - (https://github.com/Septimius21)
* **Daniil Melekh** - (https://github.com/Shiphravka)

See also the list of [contributors](https://github.com/vladisa385/ESVS/graphs/contributors) who participated in this project.

## License

This project is licensed under the MIT License

