using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Services.AddControllers();


//CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                      });
});


//db sqlite
string dbConn = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("dbError");
builder.Services.AddDbContext<AppDbContext>(db => db.UseSqlite(dbConn));
var app = builder.Build();


//middleware
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.Run();
