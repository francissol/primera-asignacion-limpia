using System;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using System.IO;
using HandlebarsDotNet;
using primeraasignacionlimpia.data;
using primeraasignacionlimpia.models;
using Scriban;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("data/appsettings.json", optional: false, reloadOnChange: true)
    .Build();

string connectionString = configuration.GetConnectionString("DefaultConnection");


var dataService = new DataService(connectionString);
using var conn = new SqlConnection(connectionString);
var persona = dataService.GetPersona();
var hobbies = dataService.GetHobbies();
var series = dataService.GetSeries();
var familia = dataService.GetFamilia();
var youtuber = dataService.GetYoutubers();

foreach (var Familia in familia)
{
    if (Familia.Foto!= null && Familia.Foto.Length >0)
    {
        Familia.Fotobase64 = Convert.ToBase64String(Familia.Foto);
    }
}

foreach (var serie in series)
{
    if (serie.Imagen != null && serie.Imagen.Length > 0)
    {
        serie.imagenbase64 = Convert.ToBase64String(serie.Imagen);
    }
}


//json cada uno
//persona
Directory.CreateDirectory("json");

var json = JsonSerializer.Serialize(persona, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("json/persona.json", json);

Console.WriteLine("Archivo JSON generado en json/persona.json");

// hobbies
var json1 = JsonSerializer.Serialize(hobbies, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("json/hobbies.json", json1);
Console.WriteLine("Archivo JSON generado en json/hobbies.json");

// series
var json2 = JsonSerializer.Serialize(series, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("json/series.json", json2);
Console.WriteLine("Archivo JSON generado en json/series.json");


//youtubers

var json3 = JsonSerializer.Serialize(youtuber, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("json/youtubers.json", json3);
Console.WriteLine("Archivo JSON generado en json/youtubers.json");

// familia

var json4 = JsonSerializer.Serialize(familia, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("json/familia.json", json4);
Console.WriteLine("Archivo JSON generado en json/familia.json");

//html

Directory.CreateDirectory("output");
//persona
var plantilla = File.ReadAllText("templantes/persona.handlebars");

var template = Handlebars.Compile(plantilla);
var html = template(persona);
File.WriteAllText("output/persona.html", html);
Console.WriteLine("Archivo HTML generado en output/persona.html");

// series

var plantilla1 = File.ReadAllText("templantes/series.handlebars");

var template1 = Handlebars.Compile(plantilla1);
var html1 = template1(series);


File.WriteAllText("output/series.html", html1);
Console.WriteLine("Archivo HTML generado en output/series.html");

//hobbies

var plantilla2 = File.ReadAllText("templantes/hobbies.handlebars");

var template2 = Handlebars.Compile(plantilla2);
var html2 = template2(hobbies);

File.WriteAllText("output/hobbies.html", html2);
Console.WriteLine("Archivo HTML generado en output/hobbies.html");

//plantilla3

var plantilla3 = File.ReadAllText("templantes/youtubers.handlebars");

var template3 = Handlebars.Compile(plantilla3);
var html3 = template3(youtuber);

File.WriteAllText("output/youtubers.html", html3);
Console.WriteLine("Archivo HTML generado en output/youtubers.html");



//plantilla4

var plantilla4 = File.ReadAllText("templantes/familia.handlebars");
var template4 = Handlebars.Compile(plantilla4);
var html4 = template4(familia);

File.WriteAllText("output/familia.html", html4);
Console.WriteLine("Archivo HTML generado en output/familia.html");

ContactoGenerator.GenerarContacto();
