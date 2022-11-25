using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//You must create local AgentDb in SQL objects explorer!
builder.Services.AddHangfire(h => h.UseSqlServerStorage("Data Source = (localdb)\\MSSQLLocalDB; " +
       "Initial Catalog = AgentDb; " +
       "Integrated Security = True; " +
       "Connect Timeout = 30; " +
       "Encrypt = False; " +
       "TrustServerCertificate = False; " +
       "ApplicationIntent = ReadWrite; " +
       "MultiSubnetFailover = False"));


builder.Services.AddControllers();
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


app.UseHangfireDashboard();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
