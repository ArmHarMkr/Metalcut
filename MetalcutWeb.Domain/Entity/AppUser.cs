using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Domain.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime UserCreatedTime { get; set; } = DateTime.Now;
    }
}
