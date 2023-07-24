using Budgy_Server.Common;
using Budgy_Server.Core.Contracts;
using Budgy_Server.Core.DTOs.Transaction;
using Budgy_Server.Extensions;
using Budgy_Server.Infrastructure.Data.Models;
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
            try
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
            try
            {
                if (id == null)
                {
                    return BadRequest();
                }

                if (!await this.transactionService.ExistByIdAsync(id))
                {
                    return NotFound(ExceptionErrors.InvalidTransaction);
                }

                var result = await this.transactionService.GetTransactionDetailsAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(Constants.GetTransaction, ex);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(CreateTransactionDto))]
        [ProducesResponseType(400, StatusCode = StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto model)
        {
            try
            {
                var userId = User.Id();

                if (userId == null)
                {
                    return BadRequest();
                }

                var result = await this.transactionService.CreateTransactionAsync(model, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(Constants.CreateTransaction);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }           
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(UpdateTransactionDto))]
        [ProducesResponseType(400, StatusCode = StatusCodes.Status400BadRequest)]
        [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EditTransaction([FromBody] UpdateTransactionDto model, string id)
        {
            try
            {
                var userId = User.Id();

                if (userId == null)
                {
                    return BadRequest();
                }

                if (!await this.transactionService.ExistByIdAsync(id))
                {
                    return NotFound(ExceptionErrors.InvalidTransaction);
                }

                var result = await this.transactionService.UpdateTransactionAsync(model, id, userId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(Constants.UpdateTransaction);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }           
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, StatusCode = StatusCodes.Status200OK, Type = typeof(Transaction))]
        [ProducesResponseType(404, StatusCode = StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTransaction(string id)
        {
            try
            {
                if (!await this.transactionService.ExistByIdAsync(id))
                {
                    return NotFound(ExceptionErrors.InvalidTransaction);
                }

                var result = await this.transactionService.DeleteTransactionAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                this.logger.LogError(Constants.DeleteTransaction);
                throw new ApplicationException(ExceptionErrors.ExceptionMessage, ex);
            }  
        }
    }
}
