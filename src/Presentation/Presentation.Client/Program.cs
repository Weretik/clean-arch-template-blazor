var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<StateContainer>();
builder.Services.AddScoped<BurgerMenuState>();
builder.Services.AddScoped<IState>(sp => sp.GetRequiredService<BurgerMenuState>());


builder.Services.AddMudServices();

await builder.Build().RunAsync();
