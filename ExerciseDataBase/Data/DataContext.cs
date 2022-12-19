using Microsoft.EntityFrameworkCore;
using ExerciseDataBase.Models;

namespace ExerciseDataBase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<CarModel> Cars { get; set; } = null!;
    }
}
