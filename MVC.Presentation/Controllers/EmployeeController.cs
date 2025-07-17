using Microsoft.AspNetCore.Authorization;
using MVC.Presentation.Utilies;
using System.Text.Json;

namespace MVC.Presentation.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<EmployeeController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public IActionResult Index()
        {
            var data = _unitOfWork.GetRepository<IEmployeeRepository>().GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(new Employee());
            return View(employeeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(_mapper.Map<EmployeeViewModel>(new Employee()));

            Employee employee = await HandleAddEditingModel(model);

            _unitOfWork.GetRepository<IEmployeeRepository>().AddAsync(employee);
            _unitOfWork.SaveChanges();
            _logger.LogInformation("Created successfully. {CorrelationId}",
                HttpContext.TraceIdentifier);



            return Ok(new { Message = "Upload successful", CorrelationId = HttpContext.TraceIdentifier });

            return RedirectToAction(nameof(Index));
        }

        private async Task<Employee> HandleAddEditingModel(EmployeeViewModel model)
        {

            Employee employee = _mapper.Map<EmployeeViewModel, Employee>(model);
            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {
                employee.ImagePath = await DocumentSettings.UploadFile(model.ProfilePicture, "uploads");
            }

            return employee;
        }

        private IActionResult GetDataHandler(int? id)
        {
            if (!id.HasValue) return BadRequest();


            var data = _unitOfWork.GetRepository<IEmployeeRepository>().GetAsync(id.Value);
            if (data is null) return NotFound();

            var employeeViewModel = _mapper.Map<EmployeeViewModel>(data);

            employeeViewModel.IsEditMode = true;
            return View(employeeViewModel);
        }

        public IActionResult Details(int? id) => GetDataHandler(id);
        public IActionResult Edit(int? id) => GetDataHandler(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, EmployeeViewModel employee)
        {
            var json = JsonSerializer.Serialize(employee, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            _logger.LogInformation("EmployeeViewModel:\n{Employee}", json);

            if (id != employee.Id) return BadRequest();
            if (!ModelState.IsValid)
                return View(_mapper.Map<EmployeeViewModel>(new Employee()));

            try
            {
                var employeeViewModel = await HandleAddEditingModel(employee);
                employeeViewModel.Id = employee.Id;
                _unitOfWork.GetRepository<IEmployeeRepository>().Update(employeeViewModel);
                if (_unitOfWork.SaveChanges() > 0)
                    TempData["Message"] = "Edit Successfully";
                _logger.LogInformation("Edited successfully. {CorrelationId}",
                HttpContext.TraceIdentifier);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                return View(employee);
            }
        }
        public IActionResult Delete(int? id) => GetDataHandler(id);

        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            var employee = await _unitOfWork.GetRepository<IEmployeeRepository>().GetAsync(id.Value);
            try
            {
                if (employee is null) return NotFound();
                _unitOfWork.GetRepository<IEmployeeRepository>().Delete(employee);
                if (_unitOfWork.SaveChanges() > 0)
                    DocumentSettings.DeleteFile(employee.ImagePath);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                return View(employee);
            }
        }

        [HttpGet("countries/{countryId}/cities")]
        public async Task<IActionResult> GetCitiesByCountry(int countryId)
        {
            var data = await _unitOfWork.GetRepository<IGenereicRepository<City>>().GetAllAsync();
            var result = data.Where(c => c.CountryId == countryId)
                        .Select(c => new CityViewModel()
                        {
                            Id = c.Id,
                            Name = c.Name,
                        });
            return Ok(new
            {
                success = true,
                data = data
            });
        }

        [HttpGet("Employee/GetALlIncludeName/{name?}")]
        public IActionResult GetALlIncludeName(string? name)
        {
            var data = _unitOfWork.GetRepository<IEmployeeRepository>().GetALlIncludeNameAsync(name);
            var employeesViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(data);
            return Ok(new
            {
                success = true,
                data = employeesViewModel
            });
        }

    }
}
