using JobApplicationTracker.Server.DB;
using JobApplicationTracker.Server.Repositories;
using JobApplicationTracker.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<JobApplicationDbContext>(options => options.UseSqlite("Data Source = JobApplicationTracker.db"));
builder.Services.AddScoped<IJobApplicationRepo, JobApplicationRepo>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Job Application Tracker API", Version = "v1"}));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:49831") // Allow the react client origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.WebHost.UseUrls("https://0.0.0.0:7198");

var app = builder.Build();


app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost");

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
