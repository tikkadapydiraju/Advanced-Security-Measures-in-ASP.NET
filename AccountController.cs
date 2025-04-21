using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(UserModel user)
    {
        var securityService = new SecurityService();
        if (securityService.ValidateUser(user.Username, user.Password))
        {
            return RedirectToAction("Dashboard");
        }
        else
        {
            ViewBag.ErrorMessage = "Invalid Username or Password!";
            return View();
        }
    }

    public IActionResult Dashboard()
    {
        return View();
    }
}
