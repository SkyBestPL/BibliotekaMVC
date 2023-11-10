using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektBibliotekaMVC.Data;
using ProjektBibliotekaMVC.Models;
using ProjektBibliotekaMVC.Utility;

namespace ProjektBibliotekaMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> CustomersIndex()
        {
            var model = await _context.Users
                                .Include(x => x.UserRoles)
                                .ThenInclude(x => x.Role)
                                .Where(x => x.UserRoles.FirstOrDefault().Role.Name == SD.RoleUserCustomer)
                                .ToListAsync();
            return View(model);
        }
        [Authorize(Roles = SD.RoleUserAdmin)]
        public async Task<IActionResult> EmployeesIndex()
        {
            var model = await _context.Users
                                .Include(x => x.UserRoles)
                                .ThenInclude(x => x.Role)
                                .Where(x => x.UserRoles.FirstOrDefault().Role.Name != SD.RoleUserCustomer)
                                .ToListAsync();
            return View(model);
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> ConfirmCustomer(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var applicationUserInput = new ApplicationUserInputModel();
            applicationUserInput.IdUser = user.Id;
            applicationUserInput.IsConfirmed = user.EmailConfirmed;
            applicationUserInput.Email = user.Email;
            return View(applicationUserInput);
        }
        [HttpPost]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> ConfirmCustomer([Bind("IdUser,IsConfirmed")] ApplicationUserInputModel applicationUserInput)
        {
            var user = await _context.Users.FindAsync(applicationUserInput.IdUser);
            user.EmailConfirmed = !user.EmailConfirmed;
            if (user.Email != "admin@admin.com")
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(CustomersIndex), new RouteValueDictionary(new { controller = "User", action = "CustomersIndex"}));
        }
        [Authorize(Roles = SD.RoleUserAdmin)]
        public async Task<IActionResult> ConfirmEmployee(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var applicationUserInput = new ApplicationUserInputModel();
            applicationUserInput.IdUser = user.Id;
            applicationUserInput.IsConfirmed = user.EmailConfirmed;
            applicationUserInput.Email = user.Email;
            return View(applicationUserInput);
        }
        [HttpPost]
        [Authorize(Roles = SD.RoleUserAdmin)]
        public async Task<IActionResult> ConfirmEmployee([Bind("IdUser,IsConfirmed")] ApplicationUserInputModel applicationUserInput)
        {
            var user = await _context.Users.FindAsync(applicationUserInput.IdUser);
            user.EmailConfirmed = !user.EmailConfirmed;
            if (user.Email != "admin@admin.com")
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(EmployeesIndex), new RouteValueDictionary(new { controller = "User", action = "EmployeeIndex" }));
        }
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var applicationUserInput = new ApplicationUserInputModel();
            applicationUserInput.IdUser = user.Id;
            applicationUserInput.IsConfirmed = user.EmailConfirmed;
            applicationUserInput.Email = user.Email;
            return View(applicationUserInput);
        }
        [HttpPost]
        [Authorize(Roles = SD.RoleUserAdmin + "," + SD.RoleUserEmployee)]
        public async Task<IActionResult> DeleteCustomer([Bind("IdUser")] ApplicationUserInputModel applicationUserInput)
        {
            var user = await _context.Users.FindAsync(applicationUserInput.IdUser);
            if (user.Email != "admin@admin.com")
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(CustomersIndex), new RouteValueDictionary(new { controller = "User", action = "CustomersIndex" }));
        }
        [Authorize(Roles = SD.RoleUserAdmin)]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            var user = await _context.Users.FindAsync(id);
            var applicationUserInput = new ApplicationUserInputModel();
            applicationUserInput.IdUser = user.Id;
            applicationUserInput.IsConfirmed = user.EmailConfirmed;
            applicationUserInput.Email = user.Email;
            return View(applicationUserInput);
        }
        [HttpPost]
        [Authorize(Roles = SD.RoleUserAdmin)]
        public async Task<IActionResult> DeleteEmployee([Bind("IdUser")] ApplicationUserInputModel applicationUserInput)
        {
            var user = await _context.Users.FindAsync(applicationUserInput.IdUser);
            if (user.Email != "admin@admin.com")
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(EmployeesIndex), new RouteValueDictionary(new { controller = "User", action = "EmployeeIndex" }));
        }
    }
}
