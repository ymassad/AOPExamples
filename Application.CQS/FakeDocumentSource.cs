using System.Linq;
using CQS;

namespace Application.CQS
{
    //In a real implementation, we would use the connectionString to connect to a database
    //I am returning fake data so that the example can run without a database
    public class FakeDocumentSource : IQueryHandler<GetDocumentsQuery, GetDocumentsResult>
    {
        private readonly string connectionString;

        public FakeDocumentSource(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public GetDocumentsResult Handle(GetDocumentsQuery query)
        {
            return
                new GetDocumentsResult(
                    Enumerable
                        .Range(1, 10)
                        .Select(x => new Document
                        {
                            Name = "Document" + x + "_" + query.Format,
                            Content = "Content" + x
                        })
                        .ToArray());
        }
    }
}
