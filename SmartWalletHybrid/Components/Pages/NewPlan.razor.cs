using Microsoft.AspNetCore.Components;
using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class NewPlan
    {
        [Parameter]
        public string budget { get; set; } = string.Empty;

        private int budgetId { get; set; }
        private string Name { get; set; } = string.Empty;
        private decimal amount { get; set; }
        private bool isIncome { get; set; } = false;

        protected override void OnParametersSet()
        {
            budgetId = Int32.Parse(budget);
        }

        private void onSavePlanClick()
        {
            Plan plan = new Plan()
            {
                Name = Name,
                BudgetId = budgetId,
                Amount = amount,
                IsIncome = isIncome,
                IsDone = false
            };
            _dbService.SavePlan(plan);
        }
    }
}
