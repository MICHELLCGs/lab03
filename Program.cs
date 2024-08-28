using Prometheus;
using ejercicio.Components;

var builder = WebApplication.CreateBuilder(args);

// Configurar los puertos aquí
builder.WebHost.UseUrls("http://+:5233");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configurar Prometheus y añadir el middleware de métricas
app.UseHttpMetrics(); // Añadir métricas para las solicitudes HTTP
app.UseRouting();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Exponer el endpoint de métricas
app.MapMetrics(); // Exponer el endpoint /metrics

app.Run();
