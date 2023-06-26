using Version.Manager.Service.IServices;
using Version.Manager.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers(
                d => d.Filters.Add<ExceptionHandle>());
builder.Services.AddScoped<IVersionManagerService, VersionManagerService>();
builder.Services.AddScoped<ISystemService, SystemService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IPublishVersionService, PublishVersionService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
