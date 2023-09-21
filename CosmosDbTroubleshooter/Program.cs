// See https://aka.ms/new-console-template for more information
using CosmosDbTroubleshooter;
using Microsoft.Azure.Cosmos;

foreach (var connectionMode in new[] { ConnectionMode.Gateway, ConnectionMode.Direct })
{
    const string accountEndpoint = "https://f9pcitstcusmtiercosmosdb.documents.azure.com:443/";
    const string authKeyOrResourceToken = "REDACTED";
    const string databaseId = "AIG";
    const string containerId = "QuoteRequestLog";
    var Id = Guid.NewGuid();
	try
	{
        var cosmosClient = new CosmosClient(accountEndpoint: accountEndpoint, authKeyOrResourceToken: authKeyOrResourceToken, new CosmosClientOptions { ConnectionMode = connectionMode });
        var container = cosmosClient.GetContainer(databaseId: databaseId, containerId: containerId);
        var itemResponse = await container.CreateItemAsync(new PolicyQuoteRequest { Id = Id.ToString() });

        Console.WriteLine($"ConnectionMode:{connectionMode} - success");
    }
    catch (CosmosException ex)
	{
        Console.Error.WriteLine($"ConnectionMode:{connectionMode} - failed\n{ex.Message}\n\n{ex.Diagnostics}");
    }
}