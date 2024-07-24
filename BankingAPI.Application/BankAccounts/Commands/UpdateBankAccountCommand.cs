using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Commands
{
    // Command to update a bank account
    public record UpdateBankAccountCommand(BankAccount BankAccount) : IRequest;
}
