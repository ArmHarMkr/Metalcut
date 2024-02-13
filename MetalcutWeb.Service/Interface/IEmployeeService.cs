using MetalcutWeb.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Service.Interface
{
    public interface IEmployeeService
    {
        Task GiveManagerRole(AppUser appUser);
        Task GiveEmployeeRole(AppUser appUser);
        Task GiveCustomerRole(AppUser appUser);
    }
}
