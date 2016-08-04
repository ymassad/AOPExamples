using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using AOP;
using AOP.CastleDynamicProxy;
using AOP.Common;

namespace Application.CastleDynamicProxy
{
    //In a real implementation, we would use the connectionString to connect to a database
    //I am returning fake data so that the example can run without a database
    public class FakeDocumentSource : IDocumentSource
    {
        private readonly string connectionString;

        public FakeDocumentSource(string connectionString)
        {
            this.connectionString = connectionString;
        }

        [return: LogCount("Number of Documents")]
        [MethodDescription("Get documents")]
        public Document[] GetDocuments([Log("Format")] string format)
        {
            return        
                Enumerable
                    .Range(1, 10)
                    .Select(x => new Document
                    {
                        Name = "Document" + x + "_" + format,
                        Content = "Content" + x
                    })
                    .ToArray();

        }
    }

}