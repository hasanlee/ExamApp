using ExamApp.DataAccessLayer.Extensions;
using ExamApp.ServiceLayer.Extensions;
using NToastNotify;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.GetDALExtensions(builder.Configuration);
builder.Services.GetSLExtensions();
builder.Services.AddControllersWithViews()
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 2000,
        ProgressBar = true,
        CloseButton = true,
    })
    .AddRazorRuntimeCompilation();

var app = builder.Build();


//Toastr
app.UseNToastNotify();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
