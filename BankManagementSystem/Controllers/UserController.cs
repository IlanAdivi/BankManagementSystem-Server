using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System;
using BankManagementSystem.Models;
using BankManagementSystem.Interfaces;

namespace BankAccountManagement.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel loginModel)
        {
            try
            {
                LoginResultModel loginResultModel = await _userLogic.LoginUser(loginModel);
                return Ok(loginResultModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            try
            {
                UserModel userModel = await _userLogic.GetUserById(id);

                if (userModel == null)
                {
                    return NotFound("User not found");
                }

                return Ok(userModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("UpdateById/{id}")]
        public async Task<IActionResult> UpdateUserById([FromBody] UpdateUserModel updateUserModel, [FromRoute] int id)
        {
            try
            {
                return Ok(await _userLogic.UpdateUserById(updateUserModel, id));
            } 
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
