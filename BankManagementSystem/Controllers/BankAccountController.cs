using BankAccountManagement.Interfaces;
using BankManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BankManagementSystem.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountLogic _bankAccountLogic;

        public BankAccountController(IBankAccountLogic bankAccountLogic)
        {
            _bankAccountLogic = bankAccountLogic;
        }

        [Authorize]
        [Route("GetAllBankAccountsByUserId/{userId}")]
        [HttpGet]
        public async Task<IActionResult> GetAllBankAccountsByUserId([FromRoute] int userId)
        {
            try
            {
                return Ok(await _bankAccountLogic.GetAllBankAccountsByUserId(userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Create/{userId}")]
        public async Task<IActionResult> CreateBankAccount([FromBody] BankAccountModel bankAccountModel, [FromRoute] int userId)
        {
            try
            {
                return Ok(await _bankAccountLogic.CreateBankAccount(bankAccountModel, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Loan/{userId}")]
        public async Task<IActionResult> LoanBankAccount([FromBody] LoanModel loanModel, [FromRoute] int userId)
        {
            try
            {
                return Ok(await _bankAccountLogic.LoanBankAccount(loanModel, userId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllBanks")]
        public IActionResult GetAllBanks()
        {
            try
            {
                return Ok(_bankAccountLogic.GetAllBanks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteBankAccount([FromRoute] int id)
        {
            try
            {
                return Ok(await _bankAccountLogic.DeleteBankAccount(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
