
using BlazorFullStackCrud.Client.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
		private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager) {
           
            _http = http;
			_navigationManager = navigationManager;
		}
        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();
		public NavigationManager NavigationManager { get; }

	

		private async Task SetHeroes(HttpResponseMessage result)
		{
			var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
			Heroes = response;
            _navigationManager.NavigateTo("superheroes");
		}

	

		public async Task GetComics()
        {
			var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null)
                Comics = result;

		}

        public async Task<SuperHero> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if (result != null)
                return  result;
            throw new Exception("Hero not found!");
        }

		public Task<SuperHero> GetSuperHero(int id)
		{
			throw new NotImplementedException();
		}

		public async Task GetSuperHeroes()
        {

            var result = await _http.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (result != null) 
                Heroes = result;

    }

        public Task<List<SuperHero>> GetDbHeroes()
        {
            throw new NotImplementedException();
        }

        public async Task CreateSuperHero(SuperHero hero)
        {
			var result = await _http.PostAsJsonAsync("api/superHero", hero);
			await SetHeroes(result);
		}

        public async Task UpdateSuperHero(SuperHero hero, int id)
        {
			var result = await _http.PutAsJsonAsync($"api/superHero/{hero.Id}", hero);
			await SetHeroes(result); 
        }

        public async Task DeleteSuperHero(int id)
        {
			var result = await _http.DeleteAsync($"api/superHero/{id}");
			await SetHeroes(result);

		}
	}
}
