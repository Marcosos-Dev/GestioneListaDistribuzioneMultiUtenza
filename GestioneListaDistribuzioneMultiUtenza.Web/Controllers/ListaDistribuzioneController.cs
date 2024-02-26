﻿using GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services;
using GestioneListaDistribuzioneMultiUtenza.Application.Factories;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Requests;
using GestioneListaDistribuzioneMultiUtenza.Application.Models.Responses;
using GestioneListaDistribuzioneMultiUtenza.Application.Services;
using GestioneListaDistribuzioneMultiUtenza.Models.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace GestioneListaDistribuzioneMultiUtenza.Web.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ListaDistribuzioneController : ControllerBase
    {
        private readonly IListaDistribuzioneService _listaDistribuzioneService;
        public ListaDistribuzioneController(IListaDistribuzioneService listaDistribuzioneService)
        {
            _listaDistribuzioneService = listaDistribuzioneService;
        }

        [HttpPost]
        [Route("addNewList")]
        public async Task<IActionResult> AggiungiListaAsync(CreateListaDistribuzioneRequest request)
        {
            int IdUtente = Convert.ToInt32(HttpContext.Items["IdUtente"]);
            var lista = request.ToEntity();
            lista.IdProprietario = IdUtente;
            await _listaDistribuzioneService.AggiungiListaAsync(lista);

            var response = new CreateListaDistribuzioneResponse();
            response.lista = new Application.Models.Dtos.ListaDistribuzioneDto(lista);
            return Ok(ResponseFactory
          .WithSuccess(response)
          );
        }
        
    }
}
