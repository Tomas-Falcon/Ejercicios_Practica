
using WebApiAplicacionC1.Models;

namespace WebApiAplicacionC1.Infraestructure
{
    public class Blog
    {
        public int BlogId { get; set; }
        public int Rating { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }
}
