namespace MVC.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet] // default method for any action method
        public IActionResult Index()
        {
            var data = _unitOfWork.GetRepository<IDepartmentRepository>().GetAll();

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

            _unitOfWork.GetRepository<IDepartmentRepository>().Add(department);
            _unitOfWork.SaveChanges();
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
                _unitOfWork.GetRepository<IDepartmentRepository>().Update(department);
                _unitOfWork.SaveChanges();
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

            var data = _unitOfWork.GetRepository<IDepartmentRepository>().Get(id.Value);
            if (data == null) return NotFound();

            return View(data);
        }

        public IActionResult Delete(int? id) => GetDataHandler(id);


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmDelete(int? id)
        {
            if (!id.HasValue) return BadRequest();

            var department = _unitOfWork.GetRepository<IDepartmentRepository>().Get(id.Value);
            if (department == null) return NotFound();
            _unitOfWork.GetRepository<IDepartmentRepository>().Delete(department);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
