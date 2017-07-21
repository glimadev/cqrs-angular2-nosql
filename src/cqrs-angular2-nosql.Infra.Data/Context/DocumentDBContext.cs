using Microsoft.Azure.Documents.Client;
using System;
using System.Configuration;

namespace cqrs_angular2_nosql.Infra.Data.Context
{
    public partial class DocumentDBContext
    {
        public DocumentClient Client { get; set; }

        public DocumentDBContext() : base()
        {
            string endpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];

            string authorizationKey = ConfigurationManager.AppSettings["PrimaryKey"];

            Client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
        }
    }
}
