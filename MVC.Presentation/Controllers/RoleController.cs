using Microsoft.AspNetCore.Identity;

namespace MVC.Presentation.Controllers;

public class RoleController : Controller
{
    private readonly IRoleService _roleService;
    private readonly IMapper _mapper;

    public RoleController(IRoleService roleService, IMapper mapper)
    {
        _roleService = roleService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var roles = await _roleService.GetAsync();
        var data = _mapper.Map<List<RoleViewModel>>(roles);

        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(RoleViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        try
        {

            IdentityRole role = new IdentityRole(model.Name);
            var result = await _roleService.CreateRoleAsync(role.Name);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }




    private async Task<IActionResult> GetDataHandler(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return BadRequest();

        var role = await _roleService.GetByIdAsync(id);
        var data = _mapper.Map<RoleViewModel>(role);
        return View(data);
    }

    public async Task<IActionResult> Details(string id) => await GetDataHandler(id);

    public async Task<IActionResult> Delete(string id) => await GetDataHandler(id);

    [HttpPost]
    public async Task<IActionResult> Delete(RoleViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name)) return BadRequest();
        var result = await _roleService.RemoveRoleAsync(model.Name);
        if (result.Succeeded)
            return RedirectToAction(nameof(Index));
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }
        return View();
    }

    public async Task<IActionResult> Edit(string id) => await GetDataHandler(id);

    [HttpPost]
    public async Task<IActionResult> Edit(RoleViewModel model)
    {
        if (string.IsNullOrEmpty(model.Name)) return BadRequest();
        if (!ModelState.IsValid) return View(model);
        try
        {
            var role = await _roleService.GetByIdAsync(model.Id);
            if (role == null) return NotFound();

            role.Name = model.Name;
            var result = await _roleService.UpdateRoleAsync(role);
            if (result.Succeeded)
                return RedirectToAction(nameof(Index));
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return View(model);
        }
    }

}
