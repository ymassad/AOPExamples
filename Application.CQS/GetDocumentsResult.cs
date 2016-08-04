using AOP.Common;

namespace Application.CQS
{
    public class GetDocumentsResult
    {
        [LogCount("Number of Documents")]
        public Document[] Documents { get; private set; }

        public GetDocumentsResult(Document[] documents)
        {
            Documents = documents;
        }
    }
}