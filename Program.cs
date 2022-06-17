var builder = WebApplication.CreateBuilder(args);

/* Scott this is optional if want to change default port and use https
   Use listenOptions.UseHttps("path-to-pfx", "optional password");

serverOptions.ListenAnyIP(8000, listenOptions =>
{
	listenOptions.UseHttps("../sslcert/apimcloud.com.pfx", "");
});

*/

builder.Services.AddControllers();

var app = builder.Build();

// <snippet_UseWebSockets>
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);
// </snippet_UseWebSockets>

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
