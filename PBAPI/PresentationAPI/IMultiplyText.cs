namespace PresentationAPI
{
    public interface IMultiplyText
    {
        Task<string> MultiplyText(FromBodyDto body);
    }
}
