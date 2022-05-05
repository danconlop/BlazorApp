using BlazorApp.Client.Services.Abstractions;
using BlazorApp.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Implementations
{
    public class GenreApi : IGenreApi
    {
        private readonly string _endpoint = "api/genre";
        private readonly HttpClient _httpClient;

        public GenreApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Add(GenreDto model)
        {
            var result = await _httpClient.PostAsJsonAsync(_endpoint, model);

            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
    }
}
