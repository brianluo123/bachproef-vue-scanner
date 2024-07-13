using BachelorproefVueScanner.Persistence;
using BachelorproefVueScanner.Services.Scans;
using BachelorproefVueScanner.Shared.Scans;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IScanService, ScanService>();

builder.Services.AddDbContext<ScannerDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyBuilder => corsPolicyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());
app.UseRouting();

/*app.UseEndpoints(endpoints => {
    endpoints.MapHealthChecks("/api/healthcheck").AllowAnonymous();
    endpoints.MapControllers();
});*/

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
