using Microsoft.AspNetCore.Components;
using Microsoft.Maui.Graphics.Text;
using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class NewAccount
    {
        [Parameter]
        public string Type { get; set; } = string.Empty;

        private bool isCategory { get; set; } = false;

        private string accountName { get; set; } = string.Empty;

        protected override void OnInitialized()
        {
            if (Type.Equals("acc"))
            {
                isCategory = true;
            }
            else
            {
                isCategory = false;
            }
            StateHasChanged();
        }

        private async void onSaveClick()
        {
            if (accountName != null &&  !accountName.Equals(""))
            {
                Account account = new Account();
                account.Name = accountName;
                account.CreateDate = DateTime.Now;
                account.IsCategory = isCategory;
                await _dbService.SaveAccount(account);
                accountName = string.Empty;
                StateHasChanged();
            }
        }

        private void onCancelClick()
        {
            accountName = string.Empty;
            StateHasChanged();
        }
    }
}
