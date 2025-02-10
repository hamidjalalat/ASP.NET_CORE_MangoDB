using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IMongoClient>(sp =>
{
    var connectionString = "mongodb://localhost:27017/";
    return new MongoClient(connectionString);
});

var app = builder.Build();



//builder.Services.AddScoped(sp =>
//{
//    var client = sp.GetRequiredService<IMongoClient>();
//    var database = "people";
//    return client.GetDatabase(database);
//});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
