using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Domain.Entity
{
    public class Department
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        [AllowNull]
        public string DepartmentName { get; set; }
    }
}
