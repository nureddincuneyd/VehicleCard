using Newtonsoft.Json;
using RestSharp;
using System.Text.Json;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Models
{
    public class ServiceMethod
    {
        readonly string apiURL = "http://localhost:13113";

        public IRestResponse GetAllProduct()
        {
            var client = new RestClient(apiURL + "/Product/GetAll");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse DeleteProduct(int id)
        {
            var client = new RestClient(apiURL + "/Product/Delete?id="+id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse CreateProduct(Product pro)
        {
            var client = new RestClient(apiURL + "/Product/Create");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(pro);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GetByIdProduct(int id)
        {
            var client = new RestClient(apiURL + "/Product/GetById?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse UpdateProduct(Product pro)
        {
            var client = new RestClient(apiURL + "/Product/Update");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(pro);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
    }
}
