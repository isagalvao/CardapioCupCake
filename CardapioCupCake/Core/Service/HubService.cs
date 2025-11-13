using CardapioCupCake.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CardapioCupCake.Core.Service
{
    public class HubService
    {

        private readonly HttpClient _httpClient;
        public HubService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://suaapi.com/") // 👉 coloque sua URL base aqui
            };
        }
        public async Task<bool> LoginAsync(string email, string senha)
        {
            var payload = new
            {
                Email = email,
                Senha = senha
            };

            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/login", content); 

            if (response.IsSuccessStatusCode)
            {
                // Você pode desserializar o token, se houver:
                // var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return true;
            }

            return false;
        }

        public async Task<bool> PostNovoCadastroAsync(CadastroModel usuario)
        {
            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                string endpoint = "api/usuarios";

                var response = await _httpClient.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na requisição de cadastro: {ex.Message}");
                throw;
            }
        }
    }
}
