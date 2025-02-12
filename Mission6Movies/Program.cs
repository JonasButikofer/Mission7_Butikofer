using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Mission6Movies.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<FilmApplicationContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FilmConnection")));

var app = builder.Build();

// Ensure migrations history table exists before applying migrations
CreateMigrationsHistoryTable();  // Step 1: Ensure the table is created

// Step 2: Apply any pending migrations after ensuring the table is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FilmApplicationContext>();
    dbContext.Database.Migrate();  // Step 2: Apply migrations
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Static method to create the migrations history table
static void CreateMigrationsHistoryTable()
{
    var connectionString = "Data Source=YourDatabaseFileName.db"; // Ensure this points to your SQLite file.
    using var connection = new SqliteConnection(connectionString);
    connection.Open();

    var command = connection.CreateCommand();
    command.CommandText = @"
        CREATE TABLE IF NOT EXISTS __EFMigrationsHistory (
            MigrationId TEXT NOT NULL,
            ProductVersion TEXT NOT NULL,
            PRIMARY KEY(MigrationId)
        );
    ";

    command.ExecuteNonQuery();
}

app.Run();
