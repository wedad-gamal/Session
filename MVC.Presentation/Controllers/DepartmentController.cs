using MVC.DAL.Entities;

namespace MVC.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _repository = departmentRepository;
        }

        [HttpGet] // default method for any action method
        public IActionResult Index()
        {
            var data = _repository.GetAll();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid) return View(department);

            _repository.Add(department);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id) => GetDataHandler(id);
        public IActionResult Edit(int? id) => GetDataHandler(id);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id) return BadRequest();

            if (!ModelState.IsValid) return View(department);

            try
            {
                _repository.Update(department);

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(department);
            }
        }

        private IActionResult GetDataHandler(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var data = _repository.Get(id.Value);
            if (data == null) return NotFound();

            return View(data);
        }

        public IActionResult Delete(int? id) => GetDataHandler(id);


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = _repository.Get(id.Value);
            if (department == null) return NotFound();
            _repository.Delete(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
