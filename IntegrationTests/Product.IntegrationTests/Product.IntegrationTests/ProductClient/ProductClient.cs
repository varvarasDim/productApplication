using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Product.IntegrationTests
{
    public static class ProductClient
    {
        private static string _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        public static List<Model.Product> GetAllProducts()
        {
            HttpClient _httpClient = new HttpClient();
            var response = _httpClient.GetAsync(_baseUrl + "api/product").Result;

            List<Model.Product> listOfProducts;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    string contentResult = content.ReadAsStringAsync().Result;
                    listOfProducts =
                        (List<Model.Product>) (new JavaScriptSerializer()).Deserialize(contentResult,
                            typeof(List<Model.Product>));
                }
            }
            else
            {
                return null;
            }

            return listOfProducts;
        }

        public static Model.Product GetProduct(int id)
        {
            HttpClient _httpClient = new HttpClient();
            var response = _httpClient.GetAsync(_baseUrl + $"api/product/{id}").Result;

            Model.Product product;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (HttpContent content = response.Content)
                {
                    string contentResult = content.ReadAsStringAsync().Result;
                    product =
                        (Model.Product)(new JavaScriptSerializer()).Deserialize(contentResult,typeof(Model.Product));
                }
            }
            else
            {
                return null;
            }

            return product;
        }

        public static bool PostProduct(Model.Product product)
        {
            HttpClient _httpClient = new HttpClient();
            var values = new Dictionary<string, string>
            {
                { "Id", product.Id.ToString() },
                { "Name", product.Name },
                { "Description", product.Description },
                { "Price", product.Price.ToString() },
                { "Is4G", product.Is4G.ToString() },
                { "Weight", product.Weight.ToString() },
            };

            var content = new FormUrlEncodedContent(values);
            var response = _httpClient.PostAsync(_baseUrl + "api/product", content).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public static bool DeleteProduct(int id)
        {
            HttpClient _httpClient = new HttpClient();
            var response = _httpClient.DeleteAsync(_baseUrl + $"api/product/{id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}
