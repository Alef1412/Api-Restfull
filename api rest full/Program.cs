using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//get busca 
//put edita dados
//post insere
//delete

app.MapGet("/user", () => new{Nome = "Alef Alexandre", Idade = "28"});

app.MapGet("/teste", (HttpResponse response) =>response.Headers.Add("teste","Alef"));

app.MapGet("teste1", (HttpResponse response) =>{
    response.Headers.Add("teste","Deu certo");
    return new {Filme = "Matrix", Genero = "Ação"};
});

app.MapPost("/salvarFilme",(Filme filme)=>{
    return filme.Cod + " - " + filme.Descricao;
});

//Query string
app.MapGet("/getFilme",([FromQuery]string dataInicio, [FromQuery]string dataFim)=>{
    return dataInicio + " - " + dataFim;
});


app.Run();

public class Filme{
    public string Cod { get; set; }

    public string Descricao { get; set; } 
}
