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


app.MapGet("/api/Traad/", (Api_Service service) =>
{
    return service.hentTraade();
});

app.MapPost("/api/Traad/", (Api_Service service, int id, string brugerTraad, string titel, string beskrivelse) =>
{
    return service.opretTraad(id, brugerTraad, titel, beskrivelse);
});

app.MapPut("/api/Traad/{id}TotalStemmer", async (Api_Service service, int id, int totalStemmer) =>
{
    int updatedTotalStemmerT = await service.OpdaterTotalStemmer(id, totalStemmer);
    if (updatedTotalStemmerT >= 0)
    {
        return Results.Ok(updatedTotalStemmerT);
    }
    else
    {
        return Results.NotFound("Tråden blev ikke fundet.");
    }
});




app.MapPost("/api/Traad/{idKommentar}", (Api_Service service, string text, int idKommentar, string brugerKommentar) =>
{
    return service.opretKommentar(text, idKommentar, brugerKommentar);
});

app.MapGet("/api/Traad/{idKommentar}", (Api_Service service) =>
{
    return service.hentKommentarer();
});



app.MapPut("/api/Traad/{idKommentar}/TotalStemmerK", async (Api_Service service, int idKommentar, int totalStemmerK) =>
{
    int updatedTotalStemmer = await service.OpdaterTotalStemmer(idKommentar, totalStemmerK);
    if (updatedTotalStemmer >= 0)
    {
        return Results.Ok(updatedTotalStemmer);
    }
    else
    {
        return Results.NotFound("Kommentaren blev ikke fundet.");
    }
});



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
