﻿using GestioneListaDistribuzioneMultiUtenza.Models.Entities;

namespace GestioneListaDistribuzioneMultiUtenza.Application.Abstractions.Services
{
    public interface IListaDistribuzioneService
    {
        Task AggiungiListaAsync(ListaDistribuzione lista);
        Task<int> OttieniProprietarioListaAsync(int IdLista);
        Task<(List<ListaDistribuzione>, int)> GetListeOfUtenteAsync(int IdUtente, int? from, int? num);
    }
}
