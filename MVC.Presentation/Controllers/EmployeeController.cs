namespace MVC.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _unitOfWork.GetRepository<IEmployeeRepository>().GetAll();
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

            _unitOfWork.GetRepository<IEmployeeRepository>().Add(employee);
            _unitOfWork.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private async Task<Employee> HandleAddEditingModel(EmployeeViewModel model)
        {

            Employee employee = _mapper.Map<EmployeeViewModel, Employee>(model);
            if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
            {
                var fileName = Path.GetFileName(model.ProfilePicture.FileName);
                var filePath = Path.Combine("wwwroot\\uploads", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ProfilePicture.CopyToAsync(stream);
                }
                employee.ImagePath = filePath.Substring(8);//remove wwwroot//
            }

            return employee;
        }

        private IActionResult GetDataHandler(int? id)
        {
            if (!id.HasValue) return BadRequest();


            var data = _unitOfWork.GetRepository<IEmployeeRepository>().Get(id.Value);
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
        public IActionResult ConfirmDelete(int? id)
        {
            var employee = _unitOfWork.GetRepository<IEmployeeRepository>().Get(id.Value);
            try
            {
                if (employee is null) return NotFound();
                _unitOfWork.GetRepository<IEmployeeRepository>().Delete(employee);
                _unitOfWork.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error", ex.Message);
                return View(employee);
            }
        }

        [HttpGet("countries/{countryId}/cities")]
        public IActionResult GetCitiesByCountry(int countryId)
        {
            var data = _unitOfWork.GetRepository<IGenereicRepository<City>>().GetAll()
                .Where(c => c.CountryId == countryId)
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
            var data = _unitOfWork.GetRepository<IEmployeeRepository>().GetALlIncludeName(name);
            var employeesViewModel = _mapper.Map<IEnumerable<EmployeeViewModel>>(data);
            return Ok(new
            {
                success = true,
                data = employeesViewModel
            });
        }

    }
}
