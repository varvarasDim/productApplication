using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Product.RequestModels;
using Product.Service.Service;

namespace Product.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/product
        //This endpoint returns a light version of the products ProductInfo
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/product")]
        public IEnumerable<Service.Model.ProductInfo> GetAll()
        {
            return _productService.GetAllProductInfos();
        }

        // GET: api/product/5
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/product/{id}")]
        public Service.Model.Product Get(int id)
        {
            return _productService.GetProduct(id);
        }


        //The following two endpoints are test endpoints and should be protected in a PROD environment (so that only the integration tests can access them in DEV)
        // POST: api/product
        [HttpPost]
        [Route("api/product")]
        public HttpStatusCode Post([FromBody] ProductPost postedProduct)
        {
            var product = Mapper.MapRequestModelToModel(postedProduct);
            _productService.AddProduct(product);

            return HttpStatusCode.OK;
        }

        // DELETE: api/product/id
        [HttpDelete]
        [Route("api/product/{id}")]
        public HttpStatusCode Delete(int id)
        {
            _productService.DeleteProduct(id);

            return HttpStatusCode.OK;
        }
    }
}
