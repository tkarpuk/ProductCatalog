using Microsoft.AspNetCore.Mvc;

namespace ProductCatalog.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode:int}")]
        public IActionResult Error(int statusCode) =>
            statusCode switch
            { 
                400 => View("BadRequest"),
                404 => View("NotFound"),
                  _ => View("Generic")
            };
    }
}
