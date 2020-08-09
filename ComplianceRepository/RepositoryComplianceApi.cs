using ComplianceRepository.Data;
using ComplianceRepository.Service;
using System;

namespace ComplianceRepository
{
    public class RepositoryComplianceApi : IRepositoryCompliance
    {
        public RepositoryComplianceApi(string applicationKey, string urlService)
        {
            _applicationKey = applicationKey;
            _httpService = new HttpService(urlService);
        }

        #region PrivateField

        private HttpService _httpService;
        private readonly XmlService _deserializeService = new XmlService();

        private string _applicationKey;
        #endregion PrivateField

        #region PrivateMethod
        private string GetToken(string applicationKey)
        {
            var requestQuery = $"logon?application_key={applicationKey}";
            var stringRespons = _httpService.RequestGet(requestQuery);

            try
            {
                var token = _deserializeService.Deserialize<TokenResponse>(stringRespons);
                if(token == null || string.IsNullOrEmpty(token.Token)) throw new Exception("Ошибка получения токена\n");
               
                return token.Token;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " " + stringRespons);
            }
        }

        private Peoples GetPeoples(string token, string query)
        {
            var requestQuery = $"people?token={token}{query}";
            var stringRespons = _httpService.RequestGet(requestQuery);
            try
            {
                var peoples = _deserializeService.Deserialize<Peoples>(stringRespons);
                if (peoples == null) throw new Exception("Ошибка получения списка людей\n");
                
                return peoples;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message + " " + stringRespons);
            }
        }
        #endregion PrivateMethod

        #region PublicMethod
        public void Init(string applicationKey, string urlService)
        {
            _applicationKey = applicationKey;
            _httpService = new HttpService(urlService);
        }

        public Peoples GetPeoples(int sinceSec = 0, int untilSec = 0)
        {
            var token = GetToken(_applicationKey);

            var query = (sinceSec == 0 ? "" : $"&since={sinceSec}") + (untilSec == 0 ? "" : $"&until={untilSec}");

            var peoples = GetPeoples(token, query);

            var nextPage = peoples.Next_page;
          
            while (nextPage == "true")
            {
                var p = GetPeoples(token, "&next_page=true");
                nextPage = p.Next_page;
                peoples.Entities.Entity.AddRange(p.Entities.Entity);
            }

            return peoples;
        }

        #endregion PublicMethod
    }
}