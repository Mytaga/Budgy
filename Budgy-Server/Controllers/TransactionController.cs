using Budgy_Server.Common;
using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Extensions;
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
        [HttpGet("all")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(AllTransactionsDto))]
        [ProducesResponseType(400, StatusCode = StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransactions()
        {
            var userId = User.Id();

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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("all/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(TransactionDetailsDto))]
        [ProducesResponseType(400, StatusCode = StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransactionDetails(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!await this.transactionService.ExistByIdAsync(id))
            {                
                return NotFound(ExceptionErrors.InvalidTransaction);
            }

            try
            {
                var result = await this.transactionService.GetTransactionDetailsAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetTransaction, ex);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }
    }
}
