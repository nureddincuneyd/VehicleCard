using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json;
using VehilceCard.ENT.Models;

namespace VehicleCard.MVC.Models
{
    public class ServiceMethod
    {
        readonly string apiURL = "http://localhost:13113";
        #region Product-Services
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
#endregion
        #region Model-Services
        public IRestResponse GetAllModel()
        {
            var client = new RestClient(apiURL + "/Model/GetAll");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            return response;
        }
        
        public IRestResponse DeleteModel(int id)
        {
            var client = new RestClient(apiURL + "/Model/Delete?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse CreateModel(Model mdl)
        {
            var client = new RestClient(apiURL + "/Model/Create");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(mdl);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GetByIdModel(int id)
        {
            var client = new RestClient(apiURL + "/Model/GetById?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse UpdateModel(Model mdl)
        {
            var client = new RestClient(apiURL + "/Model/Update");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(mdl);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
#endregion
        #region Vehicle-Services
        public IRestResponse GetAllVehicle()
        {
            var client = new RestClient(apiURL + "/Vehicle/GetAll");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            //request.AddHeader("Content-Type", "application/json");
            var response = client.Execute(request);
            return response;
        }

        public IRestResponse DeleteVehicle(int id)
        {
            var client = new RestClient(apiURL + "/Vehicle/Delete?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse CreateVehicle(Vehicle vhl)
        {
            var client = new RestClient(apiURL + "/Vehicle/Create");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(vhl);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse GetByIdVehicle(int id)
        {
            var client = new RestClient(apiURL + "/Vehicle/GetById?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", id, ParameterType.HttpHeader);
            var response = client.Execute(request);
            return response;
        }
        public IRestResponse UpdateVehicle(Vehicle vhl)
        {
            var client = new RestClient(apiURL + "/Vehicle/Update");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(vhl);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
        #endregion

        #region Product-W-Vehicle
        public IRestResponse CreatePwV(List<ProductsWithVehicles> PwV)
        {
            var client = new RestClient(apiURL + "/ProductsWithVehicles/Create");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var val = JsonConvert.SerializeObject(PwV);
            request.AddParameter("application/json", val, ParameterType.RequestBody);
            //request.AddBody(val);
            var response = client.Execute(request);
            return response;
        }
        #endregion
    }
}
