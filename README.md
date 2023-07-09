# Console Application for BilSim

This is a console application that simulates car driving with driver status and car status. The application provides various commands to interact with the car and the driver.

## Classes and Methods

### DriverService

- `GetDriverStatus()`: Returns the driver's status, including tiredness.
- `IncreaseTiredness()`: Increases the driver's tiredness by one unit.
- `Rest()`: Resets the driver's tiredness to zero.
- `GetTirednessMessage()`: Returns a message based on the driver's tiredness level.

### CarService

- `GetCarStatus()`: Returns the car's status, including direction and fuel level.
- `GetDriverStatus()`: Returns the car's status, including direction and fuel level.
- `MoveForward()`: Moves the car forward if there is enough fuel.
- `MoveBackward()`: Moves the car backward if there is enough fuel.
- `TurnRight()`: Turns the car right if there is enough fuel.
- `TurnLeft()`: Turns the car left if there is enough fuel.
- `Refuel()`: Refuels the car and restores the fuel level to maximum.

### ConsoleDisplayService

- `DisplayMenu()`: Displays the menu with available commands to interact with the car.
- `DisplayCarStatus()`: Displays the car's status, including direction, fuel level, and fuel status.
- `DisplayDriverStatus()`: Displays the driver's status, including name, age, tiredness, and tiredness status.
- `DisplayErrorMessage()`: Displays an error message on the screen.
- `GetUserInput()`: Reads the user's input from the console.

### IRandomUserService and RandomUserService

- `GetRandomUser()`: Fetches a random user from an API and returns the result.

### DriverStatus

- `Name`: Name of the driver.
- `Tiredness`: Tiredness level of the driver.

### CarStatus

- `Direction`: Direction that the car is facing.
- `FuelLevel`: Fuel level in the car.

### Driver

- `Name`: Name of the driver.
- `Age`: Age of the driver.

## Getting Started

1. Make sure you have the .NET Core SDK installed on your machine.
2. Clone the project from GitHub.
3. Open a command prompt and navigate to the project directory.
4. Run `dotnet run` to start the console application.

Now you are ready to use the console application and explore the different commands to interact with the car and the driver.
