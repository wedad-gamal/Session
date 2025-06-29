

namespace MVCWebApplication.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
        //return View("Index");
        //return View("Index", "Home");
        //return View("Index", new { name = "test" });
        //return View("Index", new { name = "test 2" });
        //return RedirectToAction("Get", "Products", new { name = "test 2" });
    }

    public IActionResult About()
    {
        return View();
    }


    public IActionResult Contact()
    {
        return View();
    }
    #region Redirect

    //public RedirectResult RedirectResult()
    //{
    //    return Redirect("https://www.google.com");
    //    //return RedirectToAction("Get", "Products", new { name = "test" });
    //    //return RedirectToRoute("default", new { controller = "Products", action = "Get", name = "test" });
    //    //return RedirectPermanent("https://www.google.com");
    //}

    //public RedirectToActionResult RedirectToActionResult()
    //{
    //    var result = new RedirectToActionResult("Get", "Products", new { name = "test 3" });
    //    return result;
    //    //return RedirectToAction("Get", "ProductsController", new { name = "test" });
    //    //return RedirectToRoute("default", new { controller = "Products", action = "Get", name = "test" });
    //    //return RedirectPermanent("https://www.google.com");
    //} 
    #endregion
}
