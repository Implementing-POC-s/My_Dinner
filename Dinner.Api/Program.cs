using Dinner.Infrastructure.Authentication;

using Microsoft.Extensions.DependencyInjection;

using Dinner.Application;
using Dinner.Infrastructure;
{
    
}
var builder = WebApplication.CreateBuilder(args);


{
    builder.Services
        .AddApplication()
        .AddInfrastructure();
    builder.Services.AddControllers();
}



var app = builder.Build();
{
    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

   
    app.MapControllers();
    app.Run();

}


