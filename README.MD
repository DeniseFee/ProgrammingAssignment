# **Funda Programming Assignment**

## **Inhoudsopgave**
1. [Projectbeschrijving](#projectbeschrijving)
2. [Architectuur](#architectuur)
3. [Installatie](#installatie)
4. [Configuratie](#configuratie)
5. [Gebruik](#gebruik)
6. [API Endpoints](#api-endpoints)
7. [Logging en Error Handling](#logging-en-error-handling)

## **Projectbeschrijving**
Deze **Funda Programming Assignment** is een ASP.NET Core project dat communicatie mogelijk maakt met de Funda API en een toplijst kan genereren van makelaars in een bepaalde plaats op basis van hun aanbod en ondersteunt ook het filteren van woningen met specifieke kenmerken, zoals een tuin.

Het project bevat foutafhandeling met retry-policy bij API-aanroepen, waarbij rekening wordt gehouden met rate-limiting en andere API-specifieke fouten via de `Refit` bibliotheek.

## **Architectuur**
- **API Layer**: Beheert HTTP-aanvragen en levert gegevens aan de frontend of externe clients.
- **Service Layer**: Bevat de logica voor het verwerken van makelaars en woningen.
- **Infra.FundaPartnerApi Layer**: Verantwoordelijk voor het communiceren met Funda Partner API.
- **Infra.Persistence Layer**: Slaat verwerkte gegevens op in de database.

Belangrijke gebruikte bibliotheken en tools:
- **Refit**: Voor eenvoudige API-integratie.
- **AutoMapper**: Voor mapping tussen DTO's en domeinmodellen.
- **Newtonsoft.Json**: Voor het deserialiseren van JSON.
- **Logging (ILogger)**: Voor logging en foutopsporing.
- **Unit Testing**: xUnit en nSubstitute voor het mocken van services en repositories.

## **Installatie**
### Vereisten
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) of [VS Code](https://code.visualstudio.com/)
- Funda Partner API Key
- SQL Server


### Stappen
1. **Clone het project:**
    ```bash
    git clone https://github.com/jouw-gebruikersnaam/funda-makelaars-api.git
    ```
2. **Ga naar de projectdirectory:**
    ```bash
    cd funda-makelaars-api
    ```
3. **Installeer de dependencies:**
   Het project maakt gebruik van `NuGet` voor dependency management. Open het project in Visual Studio of voer het volgende commando uit in de terminal:
    ```bash
    dotnet restore
    ```

4. **Build het project:**
    ```bash
    dotnet build
    ```
5. **Start een SQL Server container**
   ```shell
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Geheim!123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
   ```
6. **Instantiëer de database**
   ```shell
   dotnet ef database update --project src\ProgrammingAssignment.Api
   ```
7. **Run de applicatie via IIS Express**
## **Configuratie**
Vervang in Appsettings.json YOUR_APIKEY_HERE met jouw Api key

## **API Endpoints**
- **GET /makelaar/{plaats}**
   - **Beschrijving**: Haalt de top 10 makelaars op basis van het aantal te koop staande woningen in een bepaalde plaats.
   - **Parameters**: `plaats` (string) - de naam van de plaats.
   - **Response**: Geeft een lijst van de top 10 makelaars met hun aantal te koop staande woningen.

- **GET /makelaar/{plaats}/tuin**
   - **Beschrijving**: Haalt de top 10 makelaars op voor woningen in een bepaalde plaats die beschikken over een tuin.
   - **Parameters**: `plaats` (string) - de naam van de plaats.
   - **Response**: Geeft een lijst van de top 10 makelaars die woningen met een tuin te koop hebben.

## **Logging en Error Handling**
Het project gebruikt ILogger voor het loggen van belangrijke gebeurtenissen en fouten.

Bij API-aanroepen naar Funda wordt een retry-mechanisme toegepast wanneer de rate-limiting wordt bereikt.
ApiException Handling: Wanneer de Funda API een fout retourneert, wordt de statuscode geanalyseerd en een passend antwoord teruggegeven aan de client.
Algemene fouten worden gelogd en een generiek foutbericht wordt naar de client teruggestuurd.