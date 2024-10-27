using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class NewBudget
    {
        private string budgetName {  get; set; } = string.Empty;
        private string budgetDescription {  get; set; } = string.Empty;
        private DateTime budgetFrom { get; set; } = DateTime.Today;
        private DateTime budgetTo { get; set; } = DateTime.Today;
        private decimal budgetIncome { get; set; } = 0;
        private decimal budgetExpense { get; set;} = 0;

        private async Task onSaveClick()
        {
            Budget budget = new Budget()
            {
                Name = budgetName,
                Description = budgetDescription,
                CreateDate = DateTime.Today,
                FromDate = budgetFrom,
                ToDate = budgetTo,
                ExpectedIncome = budgetIncome,
                ExpectedExpense = budgetExpense
            };
            await _dbService.SaveBudget(budget);
            onCancelClick();
        }

        private void onCancelClick()
        {
            budgetName = string.Empty;
            budgetDescription = string.Empty;
            budgetFrom = DateTime.Today;
            budgetTo = DateTime.Today;
            budgetIncome = 0;
            budgetExpense = 0;
            StateHasChanged();
        }
    }
}
