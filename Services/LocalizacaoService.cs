using System.Text.Json;
using Atividade04.Models;

namespace Atividade04.Services
{
    public class LocalizacaoService
    {
        private readonly List<Cidade> _cities;
        private readonly List<Estado> _states;
        private readonly List<Pais> _countries;

        public LocalizacaoService(IWebHostEnvironment env)
        {
            var basePath = env.ContentRootPath + "./Data/";
            _cities = JsonSerializer.Deserialize<List<Cidade>>(File.ReadAllText(basePath + "cities.json")) ?? new List<Cidade>();
            _states = JsonSerializer.Deserialize<List<Estado>>(File.ReadAllText(basePath + "states.json")) ?? new List<Estado>();
            _countries = JsonSerializer.Deserialize<List<Pais>>(File.ReadAllText(basePath + "countries.json")) ?? new List<Pais>();
        }

        public IEnumerable<Cidade> GetCidades(string stateCode, string countryCode)
        {
            return _cities.Where(c => c.state_code == stateCode && c.country_code == countryCode);
        }

        public IEnumerable<Estado> GetEstados(string CountryCode)
        {
            return _states.Where(e => e.country_code == CountryCode);
        }

        public IEnumerable<Pais> GetPaises()
        {
            return _countries;
        }

        public IEnumerable<Cidade> GetCidadesPorNome(string citieName)
        {
            if (string.IsNullOrWhiteSpace(citieName))
            {
                return Enumerable.Empty<Cidade>();
            }

            return _cities.Where(c => c.name.Contains(citieName, StringComparison.OrdinalIgnoreCase));
        }
    }
}