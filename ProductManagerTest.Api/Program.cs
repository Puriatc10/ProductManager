using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductManagerTest.Api.SeedWork;
using ProductManagerTest.Persistance.Context;
using ProductManagerTest.Domain.Models;
using System.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ProductManagerTest.Application.Interfaces.Repository;
using ProductManagerTest.Persistance.Repositories;
using MediatR;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.Application.Handlers;
using Microsoft.AspNetCore.Builder;
using ProductManagerTest.Application.Interfaces.Service;
using ProductManagerTest.Application.Services;
using ProductManagerTest.Application.Queries;
using AutoMapper;
using ProductManagerTest.Application.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// add sql database
var dataBaseContext = builder.Configuration.GetConnectionString("SqlConnectionString");
builder.Services.AddDbContext<DataBaseContext>(x => x.UseSqlServer(dataBaseContext) , ServiceLifetime.Scoped);
builder.Services.AddIdentity<User, Role>(options =>
{
    
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<DataBaseContext>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<DataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddScoped<IRequestHandler<UserRegisterCommand, UserRegisterDto>, UserRegisterHandler>();
builder.Services.AddScoped<IRequestHandler<UserLoginCommand, UserLoginDto>, UserLoginHandler>();
builder.Services.AddScoped<IRequestHandler<AddProductCommand, AddProductDto>, AddProductHandler>();
builder.Services.AddScoped<IRequestHandler<EditProductCommand, EditProductDto>, EditProductHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteProductCommand, DeleteProductDto>, DeleteProductHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllProductsQuery, GetAllProductsDto>, GetAllProductsHandler>();
builder.Services.AddScoped<IRequestHandler<GetProductByIdQuery, GetProductByIdDto>, GetProductByIdHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllAvailableProductsQuery, GetAllAvailableProductsDto>, GetAllAvailableProductsHandler>();
builder.Services.AddScoped<IRequestHandler<GetAllAvailableProductsByUserIdQuery, GetAllAvailableProductsByUserIdDto>, GetAllAvailableProductsByUserIdHandler>();
builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
builder.Services.AddTransient<UserManager<User>, UserManager<User>>();

// add jwt authentication
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
    };
});

var app = builder.Build();

SeedWork.DbConfigure(app);

//SeedWork.DbConfigure(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.MapControllers();

app.Run();

