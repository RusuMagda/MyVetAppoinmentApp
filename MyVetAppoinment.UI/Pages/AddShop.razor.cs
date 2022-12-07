﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;

namespace MyVetAppoinment.UI.Pages
{
    public partial class AddShop
    {
        [Inject]
       
        public IShopDataService ShopDataService { get; set; }
        public ICabinetDataService CabinetDataService { get; set; }
       
        public String CabinetId;
        public String ShopName;
        public Cabinet cabinet;
        public Shop shop=new Shop();
       
        protected async Task SaveShop()
        {
            Console.WriteLine(CabinetId);
            Console.WriteLine(ShopName);
            
          
            shop.CabinetId = new Guid(CabinetId.ToString());
            shop.ShopName = ShopName.ToString();
            
            ShopDataService.AddShop(shop);
            await Task.Delay(2000);
            NavigationManager.NavigateTo("/shopsoverview");
          
        }
        public async Task Cancel()
        {

            
            NavigationManager.NavigateTo("/");
        }




    }
}