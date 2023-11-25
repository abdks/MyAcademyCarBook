using FluentValidation.AspNetCore;
using MyAcademyCarBook.BusinessLayer.Abstract;
using MyAcademyCarBook.BusinessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.Abstract;
using MyAcademyCarBook.DataAccessLayer.Concrete;
using MyAcademyCarBook.DataAccessLayer.EntityFramework;
using MyAcademyCarBook.EntityLayer.Concrete;
using MyAcademyCarBook.PresentationLayer.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CarBookContext>();
builder.Services.AddScoped<IBrandDal, EfBrandDal>();
builder.Services.AddScoped<IBrandService, BrandManager>();


builder.Services.AddScoped<ICarService,CarManager>();
builder.Services.AddScoped<ICarDal,EfCarDal>();

builder.Services.AddScoped<ICarStatusDal, EfCarStatusDal>();
builder.Services.AddScoped<ICarStatusService,CarStatusManager>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceDal,EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();

builder.Services.AddScoped<IHowItWorkStepDal, EfHowItWorksStepDal>();
builder.Services.AddScoped<IHowItWorksStepService, IHowItWorkStepManager>();


builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();


builder.Services.AddScoped<IContactFormDal, EfContactFormDal>();
builder.Services.AddScoped<IContactFormService, ContactFormManager>();


builder.Services.AddScoped<ICarCategoryService, CarCategoryManager>();
builder.Services.AddScoped<ICarCategoryDal, EfCarCategoryDal>();

builder.Services.AddScoped<IAbouttService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IAboutDService, AboutWManager>();
builder.Services.AddScoped<IAboutWDal, EfAboutWDal>();



builder.Services.AddScoped<ICarDetailDal, EfCarDetailDal>();
builder.Services.AddScoped<ICarDetailService, CarDetailManager>();

builder.Services.AddScoped<IYorumDal, EfYorumDal>();
builder.Services.AddScoped<IYorumService, YorumManager>();



builder.Services.AddScoped<IPriceDal,EfPriceDal>();
builder.Services.AddScoped<IPriceService,PriceManager>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<CarBookContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllersWithViews().AddFluentValidation();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Brand}/{action=Index}/{id?}");

app.Run();
