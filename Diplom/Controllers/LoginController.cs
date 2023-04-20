using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Diplom.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diplom.Domain.Entities;
using Diplom.Domain;

namespace Diplom.Controllers
{

    public class LoginController:Controller
    {
        private readonly DataManager dataManager;

        public LoginController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        
        public IActionResult Login()
        {
            
            return View(new LoginViewModel());
        }
        
       
        [HttpPost]
        
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                if(dataManager.Admins.GetAdminByName(model.Email)!=null)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                
            }
            return View(model);
        }
        //[Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //    await signInManager.SignOutAsync();
        //    Program.user = null;
        //    return RedirectToAction("Index", "Home");
        //}
    }
}
