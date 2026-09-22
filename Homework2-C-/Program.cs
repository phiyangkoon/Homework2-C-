using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TurnBasedRPG;
using TurnBasedRPG.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ลงทะเบียน BattleService เป็น Scoped service เพื่อเก็บสถานะเกมระหว่างหน้า
builder.Services.AddScoped<BattleService>();

await builder.Build().RunAsync();
