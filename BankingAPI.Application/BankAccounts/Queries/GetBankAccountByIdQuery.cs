using MediatR;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Queries
{
    public record GetBankAccountByIdQuery(int Id) : IRequest<BankAccount>;
}
