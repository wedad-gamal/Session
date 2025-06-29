using MVCWebApplication.Entities;
using System.Text.Json;

namespace MVCWebApplication.Controllers;

public class ProductsController : Controller
{
    //Action => public non-static method
    //[Route("products/{name}")]
    public IActionResult Get(int id, string name, Product product)
    {
        // - 1 -
        //ContentResult contentResult = new ContentResult();
        //contentResult.Content = $"ok {name}";
        //contentResult.ContentType = "text/plain";
        //return contentResult;

        // - 2 -
        return Content(JsonSerializer.Serialize(product), "application/json");

    }


}
