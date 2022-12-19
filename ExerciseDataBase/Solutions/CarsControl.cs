using ExerciseDataBase.Models;
using ExerciseDataBase.Data;

namespace ExerciseDataBase.Solutions
{
    public class CarsControl : ICarsControl
    {
        private readonly DataContext _dataContext;
        public CarsControl(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public CarModel AddCar(CarModel car)
        {
            _dataContext.Cars.Add(car);
            _dataContext.SaveChanges();
            return car;
        }

        public bool DeleteCar(int id)
        {
            CarModel car = GetCarById(id);
            
            if (car != null)
            {
                _dataContext.Cars.Remove(car);
                _dataContext.SaveChanges();
                return true;
            }
            return false;
        }

        public CarModel EditCar(CarModel car)
        {
            CarModel carEdit = GetCarById(car.Id);

            if (carEdit == null) throw new Exception("Deu ruim!");

            carEdit.Name = car.Name;
            carEdit.Year = car.Year;

            _dataContext.Cars.Update(carEdit);
            _dataContext.SaveChanges();

            return carEdit;
        }

        public CarModel GetCarById(int id)
        {
            if (_dataContext.Cars == null) throw new Exception("Deu errado");
            return _dataContext.Cars.Find(id)!;
        }
    }
}
