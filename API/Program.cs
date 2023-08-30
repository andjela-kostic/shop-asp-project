using API.Core;
using Application;
using Application.Queries.Products;
using DataAccess;
using Implementation.Logging;
using Implementation.Queries;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Application.Commands.Product;
using Implementation.Commands;
using Implementation.Validators;
using Application.Commands.User;
using Application.Email;
using Implementation.Email;
using Application.Queries.Log;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Queries.Categories;
using Application.Commands.Category;
using Application.Commands.Size;
using Application.Queries.Sizes;
using Application.Queries.SizeProducts;
using Application.Commands.SizeProducts;
using Application.Queries.Orders;
using Application.Commands.Order;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Context>();
builder.Services.AddAutoMapper(typeof(QueryableExtensions).Assembly);
builder.Services.AddTransient<UseCaseExecutor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IGetProductQuery, GetProductQuery>();
builder.Services.AddTransient<ICreateProductCommand, CreateProductCommand>();
builder.Services.AddTransient<CreateProductValidator>();
builder.Services.AddTransient<IEditProductCommand, EditProductCommand>();
builder.Services.AddTransient<EditProductValidator>();
builder.Services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
builder.Services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<IEmailSender, SmtpEmailSender>(x => new SmtpEmailSender());
builder.Services.AddTransient<IGetUseCaseLogsQuery, GetUseCaseLogsQuery>();
builder.Services.AddTransient<IGetUseCaseLogQuery, GetUseCaseLogQuery>();
builder.Services.AddTransient<IGetCategoryQuery, GetCategoryQuery>();
builder.Services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
builder.Services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
builder.Services.AddTransient<CreateCategoryValidator>();
builder.Services.AddTransient<IEditCategoryCommand, EditCategoryCommand>();
builder.Services.AddTransient<EditCategoryValidator>();
builder.Services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
builder.Services.AddTransient<DeleteCategoryValidator>();
builder.Services.AddTransient<IGetSizesQuery, GetSizesQuery>();
builder.Services.AddTransient<IGetSizeQuery, GetSizeQuery>();
builder.Services.AddTransient<ICreateSizeCommand, CreateSizeCommand>();
builder.Services.AddTransient<IEditSizeCommand, EditSizeCommand>();
builder.Services.AddTransient<IDeleteSizeCommand, DeleteSizeCommand>();
builder.Services.AddTransient<CreateSizeValidator>();
builder.Services.AddTransient<EditSizeValidator>();
builder.Services.AddTransient<DeleteSizeValidator>();
builder.Services.AddTransient<IGetSizeProductsQuery, GetSizeProductsQuery>();
builder.Services.AddTransient<ICreateSizeProductCommand, CreateSizeProductCommand>();
builder.Services.AddTransient<CreateSizeProductValidator>();
builder.Services.AddTransient<IEditSizeProductCommand, EditSizeProductCommand>();
builder.Services.AddTransient<EditSizeProductValidator>();
builder.Services.AddTransient<IDeleteSizeProductCommand, DeleteSizeProductCommand>();
builder.Services.AddTransient<DeleteSizeProductValidator>();
builder.Services.AddTransient<IGetOrdersQuery, GetOrdersQuery>();
builder.Services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
builder.Services.AddTransient<CreateOrderValidator>();

builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var user = accessor.HttpContext.User;

    if (user.FindFirst("ActorData") == null)
    {
        return new UnauthorizedActor();
    }

    var actorString = user.FindFirst("ActorData").Value;

    var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

    return actor;
});
builder.Services.AddTransient<IGetProductsQuery, GetProductsQuery>();
/* builder.Services.AddTransient<JwtManager>();
*/
builder.Services.AddTransient<JwtManager>(x =>
{
    var context = x.GetService<Context>();

    return new JwtManager(context);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{

    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = "asp_api",
            ValidateIssuer = true,
            ValidAudience = "Any",
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AndjelKosSuperSecretKey")),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
    }
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
