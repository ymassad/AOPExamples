using AOP.Common;
using AOP.CQS;

namespace Application.CQS
{
    [QueryName("Get documents")]
    public class GetDocumentsQuery
    {
        public GetDocumentsQuery(string format)
        {
            Format = format;
        }

        [Log("Format")]
        public string Format { get; private set; }
    }
}