using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de controllers
builder.Services.AddControllers();

//Adiciona o gerador do Swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para Gerenciamento de filmes - introdu��o a sprint 2 - Backend API",
        Contact = new OpenApiContact
        {
            Name = "Gabriel Henrique Silva",
            Url = new Uri("https://github.com/GabrielHenriqueas")
        },
    });

    //Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});

var app = builder.Build();

//Habilite o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

//Mapear os controllers
app.MapControllers();

app.Run();
