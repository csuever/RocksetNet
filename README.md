# RocksetNet
C# wrapper for Rockset API

## Notes
* The API is maintained and provided by Rockset (https://rockset.com). You must have an account with Rockset.
* The project targets .NET 6.0
* Rockset API Reference: https://rockset.com/docs/rest-api/

## To Do
* Query Lamdas - All
* User - Notification Preferences
* Roles - All

## Getting API key
API keys are created and managed in the Rockset Console

## Usage
A very basic example, creating a collection with name and description
```
var client = new RocksetClient("api-key-here", Region.USEast) 
var collection = new CreateCollection()
    {
        name = "NewSampleCollection",
        description = "Sample collection"
    };
    try
    {
        var response = await client.CreateCollection("commons", collection);
    }
    catch(RocksetException ex)
    {
        Console.WriteLine(ex.StatusCode);
    }
```
