namespace Application.CastleDynamicProxy
{
    public interface IDocumentSource
    {
        Document[] GetDocuments(string format);
    }
}