using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Queries
{
    // Query to get bank accounts by type
    public record GetBankAccountByIdQuery(int Id) : IRequest<BankAccount>;
}
