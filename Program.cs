
using Minimal.Data;
using Minimal.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BDContexto>();

var app = builder.Build();

//POSTs
app.MapPost("/estudante/store", (Estudante model, BDContexto contexto) =>
{
    contexto.Estudante.Add(model);
    contexto.SaveChanges();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});
app.MapPut("/estudante/update", (Estudante model, BDContexto contexto) =>
{
    contexto.Estudante.Update(model);
    contexto.SaveChanges();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});
app.MapPut("/curso/update", (Curso model, BDContexto contexto) =>
{
    contexto.Curso.Update(model);
    contexto.SaveChanges();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});

app.MapPost("/curso/store", (Curso model, BDContexto contexto) =>
{
    // var curso = new Curso(Guid.NewGuid(), "Analise e desenvolvimento de sistemas");
    contexto.Curso.Add(model);
    contexto.SaveChanges();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});
app.MapPost("/curso/delete", (Curso model, BDContexto contexto) =>
{

    var dados = contexto.Curso.FirstOrDefault(c => c.Id == model.Id);
    if (dados == null)
    {
        return "Registro não encontrado!";
    }

    contexto.Remove(dados);
    contexto.SaveChanges();
    return "Registo Apagado com sucesso!";
});
app.MapPost("/estudante/delete", (Estudante model, BDContexto contexto) =>
{

    var dados = contexto.Estudante.FirstOrDefault(c => c.Id == model.Id);
    if (dados == null)
    {
        return "Registro não encontrado!";
    }

    contexto.Remove(dados);
    contexto.SaveChanges();
    return "Registo Apagado com sucesso!";
});
app.MapPost("/estudante/delete", (Estudante model, BDContexto contexto) =>
{

    var dados = contexto.Estudante.FirstOrDefault(c => c.Id == model.Id);
    if (dados == null)
    {
        return "Registro não encontrado!";
    }

    contexto.Remove(dados);
    contexto.SaveChanges();
    return "Registo Apagado com sucesso!";
});

//GETs
app.MapGet("/estudante/{id}", (Guid id, BDContexto contexto) =>
{
    var model = contexto.Estudante.FirstOrDefault(e => e.Id == id);
    return model is not null ? Results.Ok(model) : Results.NotFound();

});

app.MapGet("/curso/{id}", (Guid id, BDContexto contexto) =>
{
    var model = contexto.Curso.FirstOrDefault(e => e.Id == id);
    return model is not null ? Results.Ok(model) : Results.NotFound();

});


app.MapGet("/estudante/list", (BDContexto contexto) =>
{
    var model = contexto.Estudante.ToList();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});

app.MapGet("/curso/list", (BDContexto contexto) =>
{
    var model = contexto.Curso.ToList();
    return model is not null ? Results.Ok(model) : Results.BadRequest();

});

app.Run();
