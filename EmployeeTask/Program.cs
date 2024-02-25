using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");

var app = builder.Build();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


app.MapGet("/employee", (AppDbContext dbContext) =>
{
    var employees = dbContext.Employees.ToList();
    return Results.Text($"Employees: {string.Join(", ", employees.Select(e => e.Name))}", "text/plain");
});

app.Run();
