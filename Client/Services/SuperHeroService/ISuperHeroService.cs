namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }

        List<Comic> Comics { get; set; }

        Task GetComics();
        Task GetSuperHeroes();

        Task<SuperHero> GetSingleHero(int id);
        Task<List<SuperHero>> GetDbHeroes();
        Task CreateSuperHero(SuperHero hero);
		Task UpdateSuperHero(SuperHero hero, int id);
        Task DeleteSuperHero(int id);
	}
}
