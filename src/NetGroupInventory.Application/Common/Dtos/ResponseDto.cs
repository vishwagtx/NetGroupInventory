namespace NetGroupInventory.Application.Common.Dtos
{
    public class ResponseDto
    {
        public bool Succeed { get; set; }
        public IList<string> Errors { get; set; }
    }
}
