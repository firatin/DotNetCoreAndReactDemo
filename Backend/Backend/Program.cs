using backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//services
builder.Services.AddControllers();

//db sqlite
string dbConn = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("dbError");
builder.Services.AddDbContext<AppDbContext>(db => db.UseSqlite(dbConn));
var app = builder.Build();


//middleware
app.MapControllers();

app.Run();
