using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ApiExample
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ApiExample()
    {
        _httpClient = new HttpClient();
        _baseUrl = "https://api.example.com/";
    }

    public async Task<string> MakeFirstApiCall()
    {
        // Make the first API call
        var response = await _httpClient.GetAsync($"{_baseUrl}first-endpoint");
        if (response.IsSuccessStatusCode)
        {
            // Read and extract the data you need from the response
            var responseData = await response.Content.ReadAsStringAsync();
            var parameter = ExtractParameterFromResponse(responseData);

            return parameter;
        }

        return null;
    }

    public async Task<string> MakeSecondApiCall(string parameterFromFirstCall)
    {
        if (parameterFromFirstCall == null)
        {
            throw new ArgumentException("Parameter from the first call is required.");
        }

        // Use the extracted parameter to construct the URL or request body for the second call
        var secondApiUrl = $"{_baseUrl}second-endpoint?param={parameterFromFirstCall}";

        // Make the second API call
        var response = await _httpClient.GetAsync(secondApiUrl);
        if (response.IsSuccessStatusCode)
        {
            var secondApiResponse = await response.Content.ReadAsStringAsync();

            return secondApiResponse;
        }

        return null;
    }

    private string ExtractParameterFromResponse(string responseData)
    {
        // Implement your logic to extract the parameter from the response
        // Example: Parsing JSON or XML
        return "extracted_parameter_value";
    }

    public async Task Main()
    {
        var parameterFromFirstCall = await MakeFirstApiCall();

        if (parameterFromFirstCall != null)
        {
            var secondApiResponse = await MakeSecondApiCall(parameterFromFirstCall);

            if (secondApiResponse != null)
            {
                Console.WriteLine("Second API Response: " + secondApiResponse);
            }
            else
            {
                Console.WriteLine("Failed to get a response from the second API call.");
            }
        }
        else
        {
            Console.WriteLine("Failed to get a parameter from the first API call.");
        }
    }
}
