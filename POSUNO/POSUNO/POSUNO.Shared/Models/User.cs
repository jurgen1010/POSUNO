using System;
using System.Collections.Generic;



namespace POSUNO.Models
{
    public class User
    {
        
        public int Id { get; set; }
        
        public string Email { get; set; }

        public string FirstName { get; set; }
     
        public string LastName { get; set; }
       
        public string Password { get; set; }

        //Propiedad de e lectura
        public string FullName => $"{FirstName} {LastName}";
    }
}
