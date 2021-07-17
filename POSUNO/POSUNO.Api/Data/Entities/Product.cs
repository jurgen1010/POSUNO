﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POSUNO.Api.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Stock { get; set; }

        public bool IsActive { get; set; }
        //Un producto pertenece a un usuario y usuario puede tener muchos productos (1 a muchos)
        [Required]
        public User User { get; set; }
    }
}
