using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using SPWebAPI.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        // POST api/<CustomerController>
        [HttpPost]

        public async Task<BaseResponse> PostAsync([FromBody] CustomerVM model)
        {
            BaseResponse response = new BaseResponse();

            string connectionString = "mongodb://localhost:27017";
            string databaseName = model.formDomainName;
            string collectionName = model.formName;

            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            var collection = db.GetCollection<Customer>(collectionName);

            var customer = new Customer { CustomerName = model.customerName, CustomerEmail = model.customerEmail, CustomerMessage = model.customerMessage };

            await collection.InsertOneAsync(customer);

            response.Success = true;

            return response;
        }

    }
}
