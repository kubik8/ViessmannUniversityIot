using System.Data.Entity;
using UniversityIot.UsersDataAccess.Models;

namespace UniversityIot.UsersDataAccess
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("UniversityIot.Users")
        {
        }

        public UsersContext(string connectionName)
            : base(connectionName)
        {
        }

        public IDbSet<User> Users { get; set; }
    }
}
