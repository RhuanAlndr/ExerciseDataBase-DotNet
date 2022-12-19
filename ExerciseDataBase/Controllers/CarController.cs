using ExerciseDataBase.Models;
using ExerciseDataBase.Data;
using Microsoft.AspNetCore.Mvc;
using ExerciseDataBase.Solutions;

namespace ExerciseDataBase.Controllers
{
    public class CarController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ICarsControl _carsControl;

        public CarController(DataContext dataContext, ICarsControl carsControl)
        {
            _dataContext = dataContext;
            _carsControl = carsControl;
        }
        public IActionResult Index()
        {
            List<CarModel> cars = new List<CarModel>(_dataContext.Cars);
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CarModel car)
        {
            if (ModelState.IsValid)
            {
                _carsControl.AddCar(car);
                return RedirectToAction("Index");
            }
            
            return View(car);
        }

        public IActionResult Edit(int id)
        {
            if(_dataContext == null)
            {
                return NotFound();
            }
            var car = _carsControl.GetCarById(id);
            
            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(CarModel car)
        {
            if(ModelState.IsValid)
            {
                _carsControl.EditCar(car);
                return RedirectToAction("Index");
            }
            return View(car);
        }

        public IActionResult Delete(int id)
        {
            if(_dataContext == null)
            {
                return NotFound();
            }
            CarModel car = _carsControl.GetCarById(id);

            return View(car);
        }

        public IActionResult DeleteConfirm(int id)
        {
            if(_dataContext == null)
            {
                return NotFound();
            }
            if (_carsControl.DeleteCar(id))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
