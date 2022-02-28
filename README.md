# RocksetNet
C# wrapper for Rockset API

Rockset API Reference: https://rockset.com/docs/rest-api/

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
