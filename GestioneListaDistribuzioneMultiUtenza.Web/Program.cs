using GestioneListaDistribuzioneMultiUtenza.Application.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Web.Extensions;
using GestioneListaDistribuzioneMultiUtenza.Models.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();
