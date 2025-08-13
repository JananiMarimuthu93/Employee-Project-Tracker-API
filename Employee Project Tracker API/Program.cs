using Employee_Project_Tracker_API.Interface;
using Employee_Project_Tracker_API.IService;
using Employee_Project_Tracker_API.Models;
using Employee_Project_Tracker_API.Repository;
using Employee_Project_Tracker_API.Service;
using Employee_Project_Tracker_API.ServiceRepository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Newtonsoft JSON config
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<EmployeeProjectTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register Repositories
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

// Register Services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IProjectService, ProjectService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
