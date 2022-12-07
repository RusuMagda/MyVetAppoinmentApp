using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyVetAppoinment.UI;
using MyVetAppoinment.UI.Pages.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<ICabinetDataService, CabinetDataService>
    (
        client => client.BaseAddress
        = new Uri(builder.HostEnvironment.BaseAddress)
    );
builder.Services.AddHttpClient<IShopDataService, ShopDataService>
    (
        client => client.BaseAddress
        = new Uri(builder.HostEnvironment.BaseAddress)
    );


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
