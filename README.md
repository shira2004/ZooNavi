# ZooNavi

ZooNavi is an innovative application designed to enhance the experience of zoo visitors. Built with C# .NET Core and Angular, ZooNavi leverages a robust security design with tokens and other measures to ensure user safety and privacy.

## Features

- **Interactive Zoo Map**: Visitors receive a link to a map showing where the animals are located.
- **Animal Information**: Each animal location on the map has a picture and detailed information about the animal.
- **Route Planning**: Users can choose the animals they want to see, and ZooNavi calculates the shortest route that passes through these points using the Google Maps API.
- **Voice Guidance and Riddles**: Next to each animal, there's an option to receive voice guidance and a riddle that earns the visitor a point if answered correctly.
- **Admin Area**: Admins can add animals, change puzzle cage positions, and manage other settings.

### Prerequisites

- .NET Core SDK
- Node.js and npm
- Angular CLI
- Google Maps API Key
- SQL Server (or any supported database)
- Angular Material

### Installation

 ## Installation
1. Clone the repository:
    ```sh
    git clone https://github.com/yourusername/ZooNavi.git
    ```

2. Navigate to the backend directory and install dependencies:
    ```sh
    cd ZooNavi/Backend
    dotnet restore
    ```

3. Navigate to the frontend directory and install dependencies:
    ```sh
    cd ../Frontend
    npm install
    ```

4. Install Angular Material:
    ```sh
    ng add @angular/material
    ```

5. Set up environment variables for Google Maps API and other configurations.

### Database Setup

1. Create a database in your SQL Server and import the schema from the `schema.sql` file:
    ```sh
    sqlcmd -S your_server -d your_database -i schema.sql
    ```

2. Update the backend configuration file with your database connection details.

### Running the Application

1. Start the backend server:
    ```sh
    cd Backend
    dotnet run
    ```

2. Start the frontend development server:
    ```sh
    cd ../Frontend
    ng serve
    ```

3. Open your browser and navigate to `http://localhost:4200`.

## Usage

### Visitor

- **View Map**: Follow the provided link to view the interactive map.
- **Select Animals**: Choose the animals you want to visit and get the shortest route.
- **Voice Guidance and Riddles**: Enable voice guidance and answer riddles for points.

### Admin

- **Manage Animals**: Add, update, or remove animals and their information.
- **Configure Puzzles**: Set up or change the positions of puzzle cages and manage riddles.

## Technologies Used

- **Backend**: C# .NET Core
- **Frontend**: Angular
- **Map Integration**: Google Maps API
- **Security**: Token-based authentication
- **Database**: SQL Server
- **UI Design**: Angular Material

## Contributing

1. Fork the repository.
2. Create your feature branch:
    ```sh
    git checkout -b feature/AmazingFeature
    ```
3. Commit your changes:
    ```sh
    git commit -m 'Add some AmazingFeature'
    ```
4. Push to the branch:
    ```sh
    git push origin feature/AmazingFeature
    ```
5. Open a pull request.

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact



## A Visual Guide
![home](https://github.com/shira2004/ZooNavi/assets/145601791/4b70c2d8-4d8e-48df-befd-213533d0c3fd)

![manager](https://github.com/shira2004/ZooNavi/assets/145601791/18174205-81c0-48a2-90d9-f0e4a0c139dc)

![trip](https://github.com/shira2004/ZooNavi/assets/145601791/4214426c-022a-4db6-95ed-4bf22d1f2078)
![map](https://github.com/shira2004/ZooNavi/assets/145601791/eb094d02-60e2-4c95-9d2d-d73f1507ebea)
