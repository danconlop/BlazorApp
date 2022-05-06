using BlazorApp.Client.Services.Abstractions;
using BlazorApp.Shared.Dto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp.Client.Services.Implementations
{
    public class MovieApi : IMovieApi
    {
        private readonly string _endpoint = "api/movie";
        private readonly HttpClient _httpclient;

        public MovieApi(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<List<MovieDto>> GetAll()
        {
            return await _httpclient.GetFromJsonAsync<List<MovieDto>>($"{_endpoint}/all");
        }

        public async Task<string> Add(MovieDto model)
        {
            var result = await _httpclient.PostAsJsonAsync(_endpoint, model);

            if (!result.IsSuccessStatusCode)
                return await result.Content.ReadAsStringAsync();

            return null;
        }
        //    public List<Movie> GetMovies()
        //    {

        //        return new List<Movie>
        //{
        //            new Movie{Title="Spiderman: Homecoming", Poster="https://media.vanityfair.com/photos/592592596736887ada186bcd/master/w_1600,c_limit/spider-man-homecoming-SMH_DOM_Online_FNL_1SHT_3DRD3DIMX_AOJ_300dpi_01_rgb.jpg", ReleaseDate = new DateTime(2007,6,28)},
        //            new Movie{Title="Spiderman: Far From Home", Poster="https://dam.smashmexico.com.mx/wp-content/uploads/2019/05/Spider-man-far-from-home-nuevos-posters-europa-05-oficial-689x1024.jpg", ReleaseDate = new DateTime(2019,7,4)},
        //            new Movie{Title="Spiderman: No Way Home", Poster="https://es.web.img3.acsta.net/r_1920_1080/pictures/21/11/16/17/13/5883722.jpg", ReleaseDate = new DateTime(2021,12,15)}
        //        };
        //    }
    }
}
