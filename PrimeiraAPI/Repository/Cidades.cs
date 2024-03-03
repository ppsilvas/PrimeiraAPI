using PrimeiraAPI.Models;
using System.Text;
using System.Text.Json;


namespace PrimeiraAPI.Repository
{
    public static class CidadesRepository
    {
        private static List<Cidade> cidades;
        private const string EnderecoJson = "C:\\Users\\asfer\\OneDrive\\Documentos\\Algoritmo\\PrimeiraAPI\\PrimeiraAPI\\PrimeiraAPI\\cidades.json";

        public static List<Cidade> Cidades
        {
            get {
                if (cidades == null)
                {
                    string jsonString = File.ReadAllText(EnderecoJson);

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        cidades = JsonSerializer.Deserialize<List<Cidade>>(jsonString);
                    }
                    else
                    {
                        CarregarCidades();
                    }

                    return cidades;
                }
                else
                {
                    return cidades;
                }
            }
        }

        private static void CarregarCidades()
        {
            cidades = new List<Cidade>()
            {
                new Cidade()
                {
                    Id = 100,
                    Nome = "Santos",
                    IdEstado = 11,
                    IdPais = 55,
                    Populacao = 300000
                },
                new Cidade()
                {
                    Id = 200,
                    Nome = "São Vicente",
                    IdEstado = 11,
                    IdPais = 55,
                    Populacao = 150000
                },
                new Cidade()
                {
                    Id = 300,
                    Nome = "Belo Horizonte",
                    IdEstado = 31,
                    IdPais = 55,
                    Populacao = 2000000
                }
            };
        }
        public static void Save()
        {
            string jsonString = JsonSerializer.Serialize(cidades);
            File.WriteAllText(EnderecoJson, jsonString, Encoding.UTF8);
        }
    }
}
