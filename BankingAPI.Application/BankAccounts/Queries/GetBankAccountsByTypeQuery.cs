using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Queries
{
    // Query to get a bank account by its unique identifier
    public record GetBankAccountsByTypeQuery(string AccountType) : IRequest<IEnumerable<BankAccount>>;

}