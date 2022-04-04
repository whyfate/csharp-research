using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Add HttpContextAccessor
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.MapGet("/fhir/Banary/{id}", (string id, IHttpContextAccessor context) =>
 {
     var path = context.HttpContext?.Request.Path.Value;
     var pattern = "/(Bb)anary/(.+)";
     var regex = new Regex(pattern);
     if (regex.IsMatch(path))
     {
         return true;
     }
     else
     {
         return false;
     }
 });

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
