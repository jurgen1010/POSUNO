using Newtonsoft.Json;
using POSUNO.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POSUNO.Helpers
{
    class ApiService
    {

        public static async Task<Response> LoginAsync(LoginRequest model)
        {
            try
            {
                //Convertimos el usuario y contraseña en formato Json
                string request = JsonConvert.SerializeObject(model);

                //Ponemos la notificacion UTF-8
                StringContent content = new StringContent(request, Encoding.UTF8, "application/json");
                
                //Consumimos nuestro servicio publicado
                string url = Settings.GetApiUrl();

                //Manejamos la cola de comunicaciones
                HttpClientHandler handler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };

                HttpClient client = new HttpClient(handler)
                {
                    BaseAddress = new Uri(url)
                };

                HttpResponseMessage response = await client.PostAsync("api/Account/Login", content);

                //Leemos el resultado
                string result = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                //Deserializamos el usuario ya que esta como un string dentro de result
                User user = JsonConvert.DeserializeObject<User>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = user,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
