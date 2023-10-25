using webAPIMiniReddit.Services;
using webAPIMiniReddit.Model;
using static System.Net.WebRequestMethods;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<Api_Service>();

var AllowSomeStuff = "_AllowSomeStuff";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSomeStuff", builder => {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//string text, int idKommentar, string brugerKommentar


app.MapGet("/api/Traad/", (Api_Service service, int id, string brugerTraad, string titel, string beskrivelse) =>
{
    return service.GetPosts(id, brugerTraad, titel, beskrivelse);
});

app.MapPost("/api/Traad/", (Api_Service service, int id, string brugerTraad, string titel, string beskrivelse) =>
{
    return service.CreatePost(id, brugerTraad, titel, beskrivelse);
});





app.MapPost("/api/Traad/{idKommentar}", (Api_Service service, string text, int idKommentar, string brugerKommentar) =>
{
    return service.CreateComment(text, idKommentar, brugerKommentar);
});

app.MapGet("/api/Traad/{idKommentar}", (Api_Service service, string text, int idKommentar, string brugerKommentar) =>
{
    return service.GetComment(text, idKommentar, brugerKommentar);
});


app.MapPut("/api/Traad/", (Api_Service service, int totalStemmer) =>
{
    return servive.GetStemmer(totalStemmer);
}

// Seed data hvis nødvendigt.
using (var scope = app.Services.CreateScope())
{
    var dataService = scope.ServiceProvider.GetRequiredService<Api_Service>();
    dataService.SeedData(); // Fylder data på, hvis databasen er tom. Ellers ikke.
}



app.UseAuthorization();

app.MapControllers();

app.UseCors(AllowSomeStuff);


app.Run();
