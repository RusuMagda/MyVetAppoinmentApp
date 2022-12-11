﻿
using Microsoft.AspNetCore.Components;
using MyVetAppoinment.Shared.Domain;
using MyVetAppoinment.UI.Pages.Services;
using System.Net.Http.Json;

namespace MyVetAppoinment.UI.Pages
{
    public partial class ShopsOverview
    {
        [Inject] public IShopDataService ShopDataService { get; set; } = default!;
        [Inject]
        public ICabinetDataService CabinetDataService { get; set; } = default!;

        public List<Shop> Shops { get; set; } = default!;
        protected List<Cabinet> userList = default!;
        protected Cabinet cabinet = default!;
        protected String cabinetName = string.Empty;
       
        protected async override Task OnInitializedAsync()
        {
            Shops =(await ShopDataService.GetAllShops()).ToList();
           
            foreach (var shop in Shops)
            {
                cabinet = (await CabinetDataService.GetCabinetDetail(shop.CabinetId));
            }
           
        }

    }
}
