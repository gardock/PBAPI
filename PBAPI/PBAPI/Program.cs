
using BusinessLogic.Repositories;
using BusinessLogic.Repositories.Interfaces;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using DB.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoListItemDBContext>(
    options => options.UseSqlServer(@"Data Source=db;Initial Catalog=PBIAPI;User id=sa;Password=SaP@ssw0rd;TrustServerCertificate=True;",
         b => b.MigrationsAssembly("DB")));

//builder.Services.AddScoped<IToDoListItemRepository, ToDoListItemListBasedRepository>();
builder.Services.AddScoped<IToDoListItemRepository, ToDoListItemRepository>();
builder.Services.AddScoped<IToDoListService, ToDoListService>();
builder.Services.AddScoped<IToDoListReadService, ToDoListReadService>();
builder.Services.AddScoped<IToDoListOrderingService, ToDoListOrderingService>();

var app = builder.Build();

//using (var Scope = app.Services.CreateScope())
//{
//    var context = Scope.ServiceProvider.GetRequiredService<ToDoListItemDBContext>();
//    context.Database.Migrate();
//}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
