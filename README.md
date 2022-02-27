# RocksetNet
Unofficial C# wrapper for Rockset API

## Notes
* The API is maintained and provided by Rockset (https://rockset.com). You must have an account with Rockset.
* The project targets .NET 6.0
* Rockset API Reference: https://rockset.com/docs/rest-api/

## To Do
* User - Notification Preferences
* Roles - All

## Getting API key
API keys are created and managed in the Rockset Console

## Usage
A very basic example: creating a collection with name and description
```
using RocksetNet.Api;
using RocksetNet.Configuration;
using RocksetNet.Exceptions;
using RocksetNet.Data;
........

var configuration = new RocksetApiConfiguration("api-key-here", Region.USEast);
var collectionApi = new CollectionsApi(configuration);

var collection = new CreateCollection()
{
    Name = "NewSampleCollection",
    Description = "Sample collection"
};

try
{
    var response = await collectionApi.Create("commons", collection);
}
catch (RocksetException ex)
{
    Console.WriteLine(ex.StatusCode);
}
```
