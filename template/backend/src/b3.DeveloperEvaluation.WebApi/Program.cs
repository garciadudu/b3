using b3.DeveloperEvaluation.Application;
using b3.DeveloperEvaluation.Domain.Validation;
using b3.DeveloperEvaluation.ORM;
using MediatR;
using Microsoft.EntityFrameworkCore;
using b3.DeveloperEvaluation.Domain.Repositories;
using b3.DeveloperEvaluation.ORM.Repository;
using b3.DeveloperEvaluation.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("b3.DeveloperEvaluation.ORM")
    )
);

builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
builder.Services.AddScoped<ICDBRepository, CDBRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(
        typeof(ApplicationLayer).Assembly,
        typeof(Program).Assembly
    )
);


builder.Services.AddCors();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
