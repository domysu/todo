using ToDo.Components;
using MongoDB.Driver;
using MongoDB.Bson;


MongoClient client = new MongoClient("mongodb+srv://dominykasvozgirdas:POFPoJVrJnzaYfHM@yessir.mpp1f.mongodb.net/?retryWrites=true&w=majority&appName=YesSir");

List<string> databases = client.ListDatabaseNames().ToList();

foreach (string database in databases)
{
    Console.WriteLine(database);
}


// POFPoJVrJnzaYfHM
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
