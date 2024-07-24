using Microsoft.AspNetCore.Mvc;
using MediatR;
using BankingAPI.Domain.Entities;
using BankingAPI.Application.BankAccounts.Queries;
using BankingAPI.Application.BankAccounts.Commands;

namespace BankingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankAccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("type/{accountType}")]
        public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccountsByType(string accountType)
        {
            var query = new GetBankAccountsByTypeQuery(accountType);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccount>> GetBankAccountById(int id)
        {
            var query = new GetBankAccountByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(int id, [FromBody] BankAccount updatedAccount)
        {
            updatedAccount.Id = id; // Ensure the ID remains the same
            var command = new UpdateBankAccountCommand(updatedAccount);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}