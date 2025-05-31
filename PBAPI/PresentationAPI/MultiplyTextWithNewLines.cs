namespace PresentationAPI
{
    public class MultiplyTextWithNewLines : IMultiplyText
    {
        public string MultiplyText(FromBodyDto body)
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
