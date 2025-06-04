var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/", async () =>
{
    return "Hello World";
});

// GET z wykorzystaniem adresu
app.MapGet("/hello-world", async () =>
{
    return "Hello World z użyciem adresu";
});

// GET z wykorzystaniem parametru z adresu
app.MapGet("/hello-world/{text}", (string text) =>
{
    return "Hello World " + text;
});

// GET z wykorzystaniem parametru z zapytania URL
app.MapGet("/hello-world-from-query", (string text) =>
{
    return "Hello World " + text;
});

// POST z parametrem z adresu
app.MapPost("/hello-world/{text}", (string text) =>
{
    return "Hello World " + text;
});

// POST wykorzystujący Body
app.MapPost("/", (FromBodyDto requestBody) =>
{
    var returnText = "";
    for (int i = 0; i < requestBody.RepeatCount; i++)
    {
        returnText += requestBody.Text + Environment.NewLine;
    }
    return returnText;
});
app.Run();

public class FromBodyDto
{
    public string Text { get; set; }
    public int RepeatCount { get; set; }
}
