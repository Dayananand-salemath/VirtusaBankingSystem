using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Commands
{
    public record UpdateBankAccountCommand(BankAccount BankAccount) : IRequest;
}
