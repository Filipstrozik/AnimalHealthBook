﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AnimalHealthBookApi.Models
{
    public class User : IdentityUser<Guid>
    {

        public IEnumerable<Animal> Animals { get; set; }
    }
}
