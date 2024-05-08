namespace PresentationAPI
{
    public class FromBodyDto
    {
        //Tego wymagajmy
        public string text { get; set; }
        //Ograniczmy to
        public int repeatCount { get; set; }
    }
}
