namespace Presentation.Pages;

public class LoginModel : PageModel
{
    public IActionResult OnGetLoginGoogle()
    {
        var redirectUrl = Url.Page("/Index");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }
}

