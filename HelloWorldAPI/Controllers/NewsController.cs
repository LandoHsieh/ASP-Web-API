using HelloWorldAPI.Models;
using HelloWorldAPI.Parameters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly WebContext _webContext;
        public NewsController(WebContext webContext)
        {
            _webContext = webContext;
        }
        
        // GET: api/<NewsController>
        [HttpGet("ByTitle")]
        public IEnumerable<News> Get(NewsParameter value)
        {
            IQueryable<News> result = _webContext.News;
            if(!string.IsNullOrEmpty(value.title)){
                result = _webContext.News.Where(a => a.Title.Contains(value.title));   
            }
            if(value.UpdateTime != null){
                result = _webContext.News.Where(a => a.UpdateDateTime.Date == value.UpdateTime);
            }
            return result;
            
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
