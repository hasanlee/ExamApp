using ExamApp.DataAccessLayer.Extensions;
using ExamApp.ServiceLayer.Extensions;
using ExamApp.ServiceLayer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.GetDALExtensions(builder.Configuration);
builder.Services.GetSLExtensions();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
