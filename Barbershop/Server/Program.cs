using Barbershop.Server.DataAcc;
using Barbershop.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<BarberContext>(options => options.UseSqlite(
builder.Configuration.GetConnectionString("BarberDbConnection")));
//builder.Services.AddDbContext<BarberSQLContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AzureDbConnection")));
builder.Services.AddScoped<BarberRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapGet("/Getallservs", async (BarberRepo repo) =>
{
return await repo.GetAllAsync();
});
app.MapPost("/Addservs", async (BarberRepo repo, BarberServDto thenewServ) =>
{
	return await repo.Addserv(thenewServ);
});

app.MapPut("/Updateservs", async (BarberRepo repo, BarberServDto Updateserv) =>
{
	return await repo.Updateserv(Updateserv);
});

app.MapDelete("/Deleteserv/{id}", async (BarberRepo repo, int id) =>
{
	return  await repo.Deleteserv(id);

});





app.MapFallbackToFile("index.html");

app.Run();
