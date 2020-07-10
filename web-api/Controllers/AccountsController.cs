using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api.Models;
using web_api.ViewModel;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("LoginAut")]

    public class AccountsController : ControllerBase
    {
        private readonly CategoryDbContext _context;

        public AccountsController(CategoryDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<bool>> GetAccount(LoginViewModel model)
        {
            var user = await _context.Accounts.Where(x => x.UserName == model.UserName && x.Password == model.PassWord).FirstOrDefaultAsync();
            if (user == null)
                return NotFound();
            else
                return true;
        }
       
    }
}
