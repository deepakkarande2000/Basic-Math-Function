using Backend_App_1.GlobalCache;
using Backend_App_1.Interface;
using Microsoft.Extensions.Caching.Memory;

namespace Backend_App_1.Repository
{
    public class CalculateRepository : ICalculatRepository
    {
        private readonly IMemoryCache _cache;
        private readonly HttpClient _httpClient;

        public CalculateRepository(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            _cache = cache;
            _httpClient = httpClientFactory.CreateClient();
        }
        public async Task<double> Calculate(double i, double j, string opName)
        {
            var cacheKey = $"{opName}-{i}-{j}";
            if (_cache.TryGetValue(cacheKey, out double cachedResult))
            {
                return (cachedResult);
            }
            else
            {
                var queryString = $"?x={i}&y={j}"; 

                var request = new Uri(GlobalCollection.PartnerAPI + opName.ToLower()+ queryString);

              var response= await FetchDataFromApiAsync(request.ToString());

                _cache.Set(cacheKey, response, TimeSpan.FromMinutes(15));

                return response;
            }
        }

        public async Task<double> FetchDataFromApiAsync(string requestUri)
        {
            try
            {
                // Send the request and wait for the response asynchronously
                var response = await _httpClient.GetAsync(requestUri);

                // Ensure the response status code indicates success
                response.EnsureSuccessStatusCode();

                // Read the response content as a string
                var responseData = await response.Content.ReadAsStringAsync();

                // Process the response data
                if (!string.IsNullOrEmpty(responseData))
                {
                    return Convert.ToDouble(responseData);
                }
                else
                {
                    // Handle the case where responseData is empty or null
                    return 0;
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                // Handle HTTP request exceptions (e.g., network issues)
                // Log or handle the exception as needed
                // For now, we just return 0 or you can throw/rethrow as per your error-handling strategy
                return 0;
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., conversion errors)
                // Log or handle the exception as needed
                // For now, we just return 0 or you can throw/rethrow as per your error-handling strategy
                return 0;
            }
        }

    }
}
