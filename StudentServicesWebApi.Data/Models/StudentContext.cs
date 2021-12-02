using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentServicesWebApi.Data.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext(): base("name=StudentContext")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
