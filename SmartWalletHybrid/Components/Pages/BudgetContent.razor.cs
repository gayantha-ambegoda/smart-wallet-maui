using Microsoft.AspNetCore.Components;
using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class BudgetContent
    {
        [Parameter]
        public string budgetId { get; set; } = string.Empty;

        private int budgetIdentity { get; set; } = 0;

        private IList<Plan> plans = new List<Plan>();
        private Budget budget = new Budget();

        protected override async Task OnParametersSetAsync()
        {
            budgetIdentity = Int32.Parse(budgetId);
            budget = await _dbService.GetBudgetById(budgetIdentity);
            plans = await _dbService.GetBudgetPlans(budgetIdentity);
        }

        private void AddNewPlan()
        {
            _navigationManager.NavigateTo("/new-plan/"+budgetId);
        }
    }
}
