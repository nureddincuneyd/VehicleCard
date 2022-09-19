using RestSharp;

namespace VehicleCard.MVC.Models
{
    public class ServiceMethod
    {
        readonly string apiURL = "http://localhost:1453";

        public IRestResponse GetAllProduct()
        {
            var client = new RestClient(apiURL + "/Product/GetAll");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            return response;
        }
    }
}
