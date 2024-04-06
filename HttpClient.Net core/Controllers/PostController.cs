using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.Net;

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

        [HttpGet("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
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

        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost(Post post)
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

        [HttpPut("EditExistingPost")]
        public async Task<IActionResult> EditExistingPost(int id, Post post)
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

        [HttpDelete("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
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

        [HttpGet("GetAllPost")]
        public async Task<IActionResult> GetAllPost()
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

        [HttpGet("Authorization")]
        public async Task<IActionResult> Authorization()
        {
            var guid = Guid.NewGuid();
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts/{guid}";

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer Your_Token_Here");

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

        [HttpGet("Timeout")]
        public async Task<IActionResult> Timeout()
        {
            var guid = Guid.NewGuid();
            var baseUrl = "https://jsonplaceholder.typicode.com/";
            var url = $"{baseUrl}posts/{guid}";

            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer Your_Token_Here");
            _httpClient.Timeout = TimeSpan.FromSeconds(30);

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

        [HttpGet("DownloadImage")]
        public async Task<IActionResult> DownloadImage()
        {
            var url = "https://via.placeholder.com/150";

            var response = await _httpClient.GetByteArrayAsync(url);

            if (response != null && response.Length > 0)
            {
                return File(response, "image/jpeg", "image.jpg");
            }
            else
            {
                return BadRequest("Failed to download image.");
            }
        }

        [HttpGet("OneClientWithMultipleRequests")]
        public async Task<IActionResult> OneClientWithMultipleRequests()
        {
            var guids = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            foreach (var guid in guids)
            {
                var baseUrl = "https://jsonplaceholder.typicode.com/";
                var url = $"{baseUrl}posts/{guid}";

                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(data);
                }
                else
                {
                    Console.WriteLine(response.StatusCode.ToString());
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
            }

            return Ok("Multiple requests completed successfully.");
        }


        [HttpGet("MakingUseofProxies")]
        public async Task<IActionResult> MakingUseofProxies()
        {
            // Define proxy settings
            HttpClientHandler handler = new HttpClientHandler
            {
                // Example of a public proxy URL and port
                Proxy = new WebProxy(new Uri("http://123.456.789.123:8080")),
                UseProxy = true
            };

            
           
            var guid = Guid.NewGuid();

            
            var baseUrl = "https://jsonplaceholder.typicode.com/";

            
            var url = $"{baseUrl}posts/{guid}";

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
