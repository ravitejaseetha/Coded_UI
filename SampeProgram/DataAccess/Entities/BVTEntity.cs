using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class BVTEntity
    {

        public BVTEntity(string firstName, string lastName, string email, string zipCode, string cityName, string stateName, string portal)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ZipCode = zipCode;
            CityName = cityName;
            StateName = stateName;
            Portal = portal;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string RepCode { get; set; }
        public string Portal { get; set; }  
    }
}
