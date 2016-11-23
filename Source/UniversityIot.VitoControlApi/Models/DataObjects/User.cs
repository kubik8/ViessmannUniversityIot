namespace UniversityIot.VitoControlApi.Models.DataObjects
{
    using System.Collections.Generic;

    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}