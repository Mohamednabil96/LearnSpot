using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using TaskDay2.Repository;
using TaskDay2.ViewModels;
using TaskDay2.Models;

namespace TaskDay2.Controllers
{
    public class AccountController : Controller
    {
        //ITIEntity context = new ITIEntity();
        IAccountRepository _accountREpo;
        public AccountController(IAccountRepository accountREpo)//inject
        {
            _accountREpo = accountREpo;
        }
        //link
        public IActionResult Register()
        {
            return View();
        }

        //save
        [HttpPost]
        public IActionResult Register(RegisterUserViewModel newAccount)
        {
            if (ModelState.IsValid)
            {
                Account account = new Account();
                account.UserName = newAccount.UserName;
                account.Password = newAccount.Password;

                _accountREpo.Create(account);
                _accountREpo.Save();
                //Cookie :Custome Identity base claims 
                ClaimsIdentity claims = new ClaimsIdentity
                    (CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(new Claim("Id", account.Id.ToString()));
                claims.AddClaim(new Claim("Name", account.UserName));
                claims.AddClaim(new Claim(ClaimTypes.Name, account.UserName));
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()));
                //get role from database using account id
                claims.AddClaim(
                    new Claim(
                        ClaimTypes.Role, _accountREpo.GetRoles(account.Id)));

                ClaimsPrincipal principle = new ClaimsPrincipal(claims);
                //response cookie ,Cookies
                HttpContext.SignInAsync
                    (CookieAuthenticationDefaults.AuthenticationScheme, principle);

                return RedirectToAction("ShowUserData");
                //  return RedirectToAction("Index", "Department");
            }
            return View(newAccount);
        }

        //[Authorize]//cookie can access this Action
        [Authorize(Roles = "Admin")]//cookie.claim[Role]=Admin
        public IActionResult ShowUserData()
        {
            //  User.Identity.Name
            //logic
            //check request.cookie[cookie]==>Cliampricple
            //User.Claims //key cookie
            //if(User.Identity.IsAuthenticated == true)
            //{
            //if(User.IsInRole("Admin"))
            //Claim nameClaim =  User.Claims.FirstOrDefault(c => c.Type == "Name");
            return Content("Welcome" + User.Identity.Name);//nameClaim.Value);
            //}
            //  return RedirectToAction("Login","Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//check request.form["__RequestVerificationToken"]
        public IActionResult Login(Account account)
        {
            if (_accountREpo.Find(account.UserName, account.Password))
            {
                //get account
                Account AccountModel = _accountREpo.Get(account.UserName, account.Password);
                //create cookie
                ClaimsIdentity claims =
                    new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claims.AddClaim(
                    new Claim(ClaimTypes.NameIdentifier, AccountModel.Id.ToString()));
                claims.AddClaim(
                    new Claim(ClaimTypes.Name, AccountModel.UserName.ToString()));
                claims.AddClaim(
                    new Claim(ClaimTypes.Role, _accountREpo.GetRoles(AccountModel.Id)));



                ClaimsPrincipal principle =
                    new ClaimsPrincipal(claims);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                //return RedirectToAction("ShowUserData");
                return RedirectToAction("Index", "Employee");

            }
            return View(account);
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
