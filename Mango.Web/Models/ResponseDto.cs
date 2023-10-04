namespace Mango.Web.Models
{
    public class ResponseDto
    {
        public bool InSeccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessgaes { get; set; }

    }
}
