The application was built with VS Code 1.147 and .NET 11.
Prerequisites: Ensure you have the .NET SDK and the C# Dev Kit installed in VS Code.
Run: Open the VS Code integrated terminal (`Ctrl+``). Start the local server with dotnet run.
The terminal will output the localhost port your API is listening on (http://localhost:5082).

The API key and the base URL are configured in the appsettings.json file.

Architecture: the Aggregator class implements the aggregation logic.
The AggregatorService class connects to the server and fetches the data.
A few classes such as ApiResponse, Record, Category support the JSON serialization.
The Program.cs file is initially auto-generated, then REST service logic was added.

Limitations: The most recently updated record is not implemented.
The stg.prologmobile.com API started throwing a 429 error, too many requests.
