using site1.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var basePath = builder.Configuration["BASE_PATH"];
builder.Services.AddSingleton(new BasePathConfig { Path = basePath });
var app = builder.Build();

if (!string.IsNullOrEmpty(basePath))
{
    basePath = basePath.TrimStart('/').TrimEnd('/');
    app.UsePathBase($"/{basePath}");
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
