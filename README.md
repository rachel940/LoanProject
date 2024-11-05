
# LoanProject

This repository contains two separate projects:
1. **server** - A .NET 8 backend application
2. **client** - A React frontend application

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version X.X or higher)
- [Node.js and npm](https://nodejs.org/) (for the React application)
- [Visual Studio Code](https://code.visualstudio.com/) or another IDE of your choice

---

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/rachel940/LoanProject.git
cd loan-project
```

### Running the Server (.NET)

1. Navigate to the Server folder:

    ```bash
    cd Server/LoanCalculation
    ```

2. Restore the .NET dependencies:

    ```bash
    dotnet restore
    ```

3. Build the project:

    ```bash
    dotnet build
    ```

4. Run the server:

    ```bash
    dotnet run
    ```

   The server should now be running at `http://localhost:21089/swagger`.
   I created an API to add customers to the existing file. Can be added through Swagger in the CreateClient API.

### Running the Client (React)

1. Open a new terminal window and navigate to the Client folder:

    ```bash
    cd Client
    ```

2. Install the npm dependencies:

    ```bash
    npm install
    ```

3. Start the React application:

    ```bash
    npm start
    ```

   The client should now be running at `http://localhost:3000`.

---
