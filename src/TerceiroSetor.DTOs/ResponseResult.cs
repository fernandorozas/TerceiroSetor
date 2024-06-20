namespace TerceiroSetor.DTOs
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
