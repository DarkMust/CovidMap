# CovidMap Web App

A .NET web application displaying real-time COVID-19 statistics, news, and a dynamic map.

## Features

*   Global and continent-level COVID-19 statistics.
*   Dynamic map with country-specific COVID-19 data on click.
*   Latest COVID-19 news feed.
*   Modern glassy design.

## Live Demo

Check out the live application deployed on Azure: [https://covidmap-gahzazcsgehzcxbg.francecentral-01.azurewebsites.net/](https://covidmap-gahzazcsgehzcxbg.francecentral-01.azurewebsites.net/)

## Technologies Used

*   ASP.NET Core
*   Razor Pages
*   C#
*   JavaScript
*   HTML/CSS
*   Leaflet.js (for the map)
*   Bootstrap (for basic styling and responsiveness)
*   disease.sh API (for COVID-19 data)
*   News API (for news)

## Setup and Running Locally

1.  **Clone the repository:**
    ```bash
    git clone <your-github-repo-url>
    cd CovidMap/CovidMap # Navigate to the project directory
    ```
2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Configure News API Key:**
    *   Obtain an API key from [News API](https://newsapi.org/).
    *   The `NewsApiKey` is not stored in the committed `appsettings.json` for security reasons.
    *   To run the application (locally or in production), you **must** provide the `NewsApiKey` via an environment variable.
    *   **How to set an environment variable:**
        *   **Windows:** In Command Prompt: `setx NewsApiKey "YOUR_API_KEY"`. In PowerShell: `$env:NewsApiKey="YOUR_API_KEY"` (for current session) or use System Properties.
        *   **macOS/Linux (for current session):** `export NewsApiKey="YOUR_API_KEY"`. To make it permanent, add this line to your shell profile file (e.g., `~/.bashrc`, `~/.zshrc`, `~/.profile`) and restart your terminal.
        *   **Hosting Platforms (Azure, AWS, Docker, etc.):** Refer to your platform's documentation for how to configure application settings or environment variables.

4.  **Run the application:**
    ```bash
    dotnet run
    ```
    The application should now be running, typically at `https://localhost:5001` or `http://localhost:5000`.

## Building for Production

To create a production-ready build, use the following command:

```bash
dotnet publish -c Release -o ./publish
```

This will create a publish directory (`./publish`) with the necessary files for deployment.

## Deployment

The published output can be deployed to various hosting environments that support ASP.NET Core applications, such as:

*   Azure App Services
*   AWS Elastic Beanstalk
*   Docker containers
*   IIS/Kestrel

Refer to the documentation for your chosen hosting provider for specific deployment steps.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License

[MIT License](LICENSE) 