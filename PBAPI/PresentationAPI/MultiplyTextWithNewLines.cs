namespace PresentationAPI
{
    public class MultiplyTextWithNewLines : IMultiplyText
    {
        public async Task<string> MultiplyText(FromBodyDto body)
        {
            var returnText = "";
            for (int i = 0; i < body.repeatCount; i++)
            {
                returnText += body.text + System.Environment.NewLine;
            }
            return returnText;
        }
    }
}
