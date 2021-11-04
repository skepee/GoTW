using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GoTW
{
    public class GoTWHttp
    {
        private readonly HttpClient _httpClient;

        public GoTWHttp(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<CommandersDTO> GetCommanderSkills(string skill)
        {
            var res = await _httpClient.GetFromJsonAsync<CommandersDTO>("api/Commanders/"+ skill);
            return res;
        }
    }
}
