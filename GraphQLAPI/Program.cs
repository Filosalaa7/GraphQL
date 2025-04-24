using System.Text;
using AppAny.HotChocolate.FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using School.API.DataLoaders;
using School.API.Mappings;
using School.API.Schema;
using School.API.Validators;
using School.Core.Interfaces;
using School.Core.Models;
using School.Core.Models.Authentication;
using School.Infrastructure;
using School.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<Queries>()
    .AddMutationType<Mutation>()
    .AddDataLoader<InstructorDataLoader>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddFluentValidation(o =>
    {
        o.UseDefaultErrorMapper();
    });


builder.Services.AddDbContextFactory<SchoolDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).LogTo(Console.WriteLine));


builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });


builder.Services.AddHttpContextAccessor();


builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddTransient<CourseTypeInputValidator>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SchoolDbContext>();
builder.Services.AddScoped<IAuthService, AuthService>();


builder.Services.AddScoped<CoursesRepository>();
builder.Services.AddScoped<InstructorRepository>();

builder.Services.AddAutoMapper(typeof(CourseMappingProfile));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
