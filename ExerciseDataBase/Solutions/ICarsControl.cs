using ExerciseDataBase.Models;

namespace ExerciseDataBase.Solutions
{
    public interface ICarsControl
    {
        CarModel AddCar(CarModel car);
        CarModel EditCar(CarModel car);
        bool DeleteCar(int id);
        CarModel GetCarById(int id);
    }
}
