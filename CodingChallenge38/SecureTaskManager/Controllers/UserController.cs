using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureTaskManager.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        public IActionResult TaskList() => View();

        [Authorize(Policy = "CanEditTask")]
        public IActionResult EditTask(int id) => View();
    }
}
