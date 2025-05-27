using School.Core.Models;

namespace School.API.Schema
{
    public class GrpcQueries
    {
        private readonly HttpClient _httpClient;

        public GrpcQueries(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("GrpcJson");
        }

        public async Task<IEnumerable<ToDoItem>> GetAllGrpc()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ToDoItem>>("/v1/todos");
            return result ?? new List<ToDoItem>();
        }
    }
}
