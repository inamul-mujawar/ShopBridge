
using System.Net;

namespace ShopBridge.Models
{
    public class DBResponseModel
    {
        public int? ResponseId { get; set; }
        public HttpStatusCode responseMsg { get; set; }
    }
}