using Budgy_Server.Common;
using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Transaction;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Budgy_Server.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService transactionService;
        private readonly IAccountService accountService;
        private readonly ILogger<TransactionController> logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger, IAccountService accountService)
        {
            this.transactionService = transactionService;
            this.logger = logger;
            this.accountService = accountService;   
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("getAll/{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllTransactionsDto))]
        [ProducesResponseType(400, StatusCode = StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransactions(string userId)
        {
            if (userId == null)
            {
                return BadRequest();
            }

            if (!await this.accountService.ExistByIdAsync(userId))
            {
                return NotFound(ExceptionErrors.InvalidUser);
            }

            try
            {
                var result = await this.transactionService.GetTrasactionsAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetTransactions, ex);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }          
        }
    }
}
