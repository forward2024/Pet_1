var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MongoDBContext>(serviceProvider =>
{
    return new MongoDBContext(
        builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString"),
        builder.Configuration.GetValue<string>("MongoDbSettings:DatabaseName"));
});

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();