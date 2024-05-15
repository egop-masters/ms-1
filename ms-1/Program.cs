using Prometheus;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseRouting();
// Map the /metrics endpoint for Prometheus
app.UseHttpMetrics(options => options.CaptureMetricsUrl = false); // Middleware for recording HTTP metrics
app.MapMetrics(); // Endpoint for Prometheus to scrape metrics

// Map the root endpoint
app.MapGet("/test-endpoint", () => "Hello from ms-1");

app.Run();