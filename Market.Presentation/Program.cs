using Market.Application;
using Market.Application.Authentication;
using Market.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();
builder.Services.AddScoped<IRoleApplicationService, RoleApplicationService>();
builder.Services.AddSingleton<ITokenService, TokenService>();
// Add Application Services
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();
builder.Services.AddScoped<IAddressApplicationService, AddressApplicationService>();
builder.Services.AddScoped<IBrandApplicationService, BrandApplicationService>();
builder.Services.AddScoped<ICategoryApplicationService, CategoryApplicationService>();
builder.Services.AddScoped<ICategoryOptionApplicationService, CategoryOptionApplicationService>();
builder.Services.AddScoped<ICategoryOptionValueApplicationService, CategoryOptionValueApplicationService>();
builder.Services.AddScoped<IFactorApplicationService, FactorApplicationService>();
builder.Services.AddScoped<IInvoiceApplicationService, InvoiceApplicationService>();
builder.Services.AddScoped<IOptionApplicationService, OptionApplicationService>();
builder.Services.AddScoped<IOptionValueApplicationService, OptionValueApplicationService>();
builder.Services.AddScoped<IOrderApplicationService, OrderApplicationService>();
builder.Services.AddScoped<IPaymentApplicationService, PaymentApplicationService>();
builder.Services.AddScoped<IPaymentTransactionApplicationService, PaymentTransactionApplicationService>();
builder.Services.AddScoped<IPriceApplicationService, PriceApplicationService>();
builder.Services.AddScoped<IProductApplicationService, ProductApplicationService>();
builder.Services.AddScoped<IProductOptionApplicationService, ProductOptionApplicationService>();
builder.Services.AddScoped<IProductOptionValueApplicationService, ProductOptionValueApplicationService>();
builder.Services.AddScoped<IProductPriceApplicationService, ProductPriceApplicationService>();
builder.Services.AddScoped<IShopApplicationService, ShopApplicationService>();
builder.Services.AddScoped<IShopProductOptionValueApplicationService, ShopProductOptionValueApplicationService>();
builder.Services.AddScoped<ITransactionApplicationService, TransactionApplicationService>();
builder.Services.AddScoped<IUsersAddressApplicationService, UsersAddressApplicationService>();
builder.Services.AddScoped<IVariantValueApplicationService, VariantValueApplicationService>();

// For Entity Framework
builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject", Version = "v1.0.0" });

    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securitySchema);

    var securityRequirement = new OpenApiSecurityRequirement {
        { securitySchema, new[] { "Bearer" } }
    };

    c.AddSecurityRequirement(securityRequirement);

});

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                      });
});


var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();