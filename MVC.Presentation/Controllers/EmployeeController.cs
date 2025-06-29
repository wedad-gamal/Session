using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.DAL.Entities;
using MVC.Presentation.ViewModels;

namespace MVC.Presentation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IGenereicRepository<Employee> _repository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IGenereicRepository<City> _cityRepository;
        private readonly IGenereicRepository<Country> _countryRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IGenereicRepository<Employee> repository,
            IDepartmentRepository departmentRepository,
            IGenereicRepository<City> cityRepository,
            IGenereicRepository<Country> countryRepository,
            IMapper mapper)
        {
            _repository = repository;
            _departmentRepository = departmentRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var data = _repository.GetAll();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(BuildViewModel(new EmployeeViewModel()));
        }
        private EmployeeViewModel BuildViewModel(EmployeeViewModel employeeViewModel)
        {
            employeeViewModel.GenderList = Enum.GetValues(typeof(Gender))
                                               .Cast<Gender>()
                                               .Select(g => new SelectListItem
                                               {
                                                   Value = ((int)g).ToString(),
                                                   Text = g.ToString()
                                               });
            employeeViewModel.Departments = _departmentRepository.GetAll().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });
            employeeViewModel.Countries = _countryRepository.GetAll().Select(c => new SelectListItem()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            return employeeViewModel;


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            Employee employee = await HandleAddEditingModel(model);

            _repository.Add(employee);

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

            ViewBag.GenderList = new SelectList(Enum.GetValues(typeof(Gender)));
            var data = _repository.Get(id.Value);
            if (data is null) return NotFound();
            var employeeViewModel = _mapper.Map<EmployeeViewModel>(data);
            employeeViewModel = BuildViewModel(employeeViewModel);
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
            if (!ModelState.IsValid) View(BuildViewModel(new EmployeeViewModel()));

            try
            {
                var employeeViewModel = await HandleAddEditingModel(employee);
                employeeViewModel.Id = employee.Id;
                _repository.Update(employeeViewModel);
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
            var employee = _repository.Get(id.Value);
            try
            {
                if (employee is null) return NotFound();
                _repository.Delete(employee);
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
            var data = _cityRepository.GetAll()
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

    }
}
