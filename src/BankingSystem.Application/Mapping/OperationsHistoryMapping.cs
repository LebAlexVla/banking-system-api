using BankingSystem.Application.Contracts.UserSession.Models;
using BankingSystem.Domain.BankAccounts;
using System.Text;

namespace BankingSystem.Application.Mapping;

public static class OperationsHistoryMapping
{
    public static BankAccountOperationsHistoryDto MapToDto(this IEnumerable<OperationType> operationsHistory)
    {
        var sb = new StringBuilder();
        foreach (OperationType operation in operationsHistory)
        {
            sb.Append(operation.ToString());
            sb.Append(':');
            switch (operation)
            {
                case OperationType.GetBalanceOperation(var amount):
                    sb.AppendLine(amount.ToString());
                    break;
                case OperationType.ReplenishOperation(var amount):
                    sb.AppendLine(amount.ToString());
                    break;
                case OperationType.WithdrawMoneyOperation(var amount):
                    sb.AppendLine(amount.ToString());
                    break;
            }
        }

        return new BankAccountOperationsHistoryDto(sb.ToString());
    }
}