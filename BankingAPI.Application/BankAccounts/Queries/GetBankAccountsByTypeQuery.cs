using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Queries
{
    
    public record GetBankAccountsByTypeQuery(string AccountType) : IRequest<IEnumerable<BankAccount>>;

}