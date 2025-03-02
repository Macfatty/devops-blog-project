using DevOpsApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB as a service
builder.Services.AddSingleton<MongoDBService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  //  Ensures static files work
app.UseRouting();
app.UseAuthorization();

//  Define default route for controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

