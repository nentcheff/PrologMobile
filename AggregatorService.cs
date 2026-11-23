namespace PrologMobile;

using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

public class AggregatorService(
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration,
    ILogger<AggregatorService> logger)
{
    private readonly string baseUrl = configuration["baseUrl"] ?? "";
    private readonly string apiKey = configuration["apiKey"] ?? "";
    public async Task<List<Category>> AggregateAsync()
    {
        try
        {
            List<Record> records = [];
            ApiResponse response = await CallApi(page: 1);
            records.AddRange(response.Records);
            int totalPages = response.TotalPages;
            for (int page = 2; page <= totalPages; page++)
            {
                response = await CallApi(page);
                records.AddRange(response.Records);
            }
            List<Category> result = [.. Aggregator.Aggregate(records)];
            return result;
        }
        catch (Exception e)
        {
            // Writes in Debug Console
            logger.LogError(e, "Error in AggregateAsync.");
            throw new HttpRequestException("Error in AggregateAsync.", e, HttpStatusCode.InternalServerError);
        }
    }

    private async Task<ApiResponse> CallApi(int page)
    {
        HttpClient client = httpClientFactory.CreateClient();

        client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        ApiResponse response = await client.GetFromJsonAsync<ApiResponse>(
            $"{baseUrl}/api/records?page={page}&pageSize=25"
        ) ?? new ApiResponse();
        return response;
    }
}
