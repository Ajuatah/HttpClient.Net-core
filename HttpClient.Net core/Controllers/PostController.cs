using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

namespace HttpClient.Net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PostController : ControllerBase
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public PostController(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts/{id}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts";

            var jsonContent = JsonConvert.SerializeObject(post);
            var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(url, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Post post)
        {
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts/{id}";

            var jsonContent = JsonConvert.SerializeObject(post);
            var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(url, requestContent);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts/{id}";

            var response = await _httpClient.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return Ok(data);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }

    public class Post
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}
