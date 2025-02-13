var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors((options) =>
{
   options.AddPolicy("AllowAll", policy => 
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()); 
});

var app = builder.Build();
app.UseCors("AllowAll");

app.Run();