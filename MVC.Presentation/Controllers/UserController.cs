namespace MVC.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public UserController(IUserService userService,
            ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            List<UserViewModel> result = _mapper.Map<List<UserViewModel>>(users);
            return View(result);
        }

        [HttpGet("User/search/{name?}")]
        public async Task<IActionResult> search(string? name)
        {
            var users = await _userService.GetUserByUserNameAsync(name);
            var data = _mapper.Map<UserViewModel>(users);
            return Ok(new
            {
                success = true,
                data = data
            });
        }

        public async Task<IActionResult> Details(string id) => await HandleUserDetails(id);

        private async Task<IActionResult> HandleUserDetails(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var data = _mapper.Map<UserViewModel>(user);

            //incase edit

            var userRoles = await _userService.GetUserRolesDtoAsync(id);
            data.UserRoleViewModel = _mapper.Map<List<UserRoleViewModel>>(userRoles);

            return View(data);
        }

        public async Task<IActionResult> Edit(string id) => await HandleUserDetails(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id, UserViewModel model)
        {
            if (id != model.Id) return BadRequest();

            if (!ModelState.IsValid) return View(model);

            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                var userRoles = await _userService.GetUserRolesAsync(id);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                foreach (var userRole in model.UserRoleViewModel)
                {
                    if (userRole.IsAssigned && !userRoles.Contains(userRole.Name))
                        await _userService.AssignRoleToUserAsync(id, userRole.Name);
                    else if (!userRole.IsAssigned && userRoles.Contains(userRole.Name))
                        await _userService.RemoveRoleFromUserAsync(id, userRole.Name);
                }
                var result = await _userService.UpdateUserAsync(user);

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    return View(model);
                }

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(string id) => await HandleUserDetails(id);


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();

            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                await _userService.DeleteUserAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting user with ID {id} - {ex.Message}");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
