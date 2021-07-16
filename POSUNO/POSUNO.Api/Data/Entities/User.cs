using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace POSUNO.Api.Data.Entities
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        [EmailAddress] //Valida que sea un email valido
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        public string Password { get; set; }

        //Para conocer los articulos que tiene un usuario, para definir la relacion a ambos lados (1 a muchos)
        public ICollection<Product> Products { get; set; }
    }
}
