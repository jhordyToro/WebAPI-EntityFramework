using minimalAPIef;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TaskContext>(builder.Configuration.GetConnectionString("cnHomeWork"));
builder.Services.AddScoped<IHelloWorldService, HelloWorldServices>();
// builder.Services.AddScoped<IHelloWorldService>(p => new HelloWorldServices());
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ITaskService, TaskService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// app.UseWelcomePage();

// app.UseTimeMiddleware();

app.MapControllers();

app.Run();
