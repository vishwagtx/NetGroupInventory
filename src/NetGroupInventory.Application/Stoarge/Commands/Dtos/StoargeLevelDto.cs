using System.ComponentModel.DataAnnotations;

namespace NetGroupInventory.Application.Stoarge.Commands.Dtos
{
    public class StoargeLevelDto
    {
        [Required]
        [StringLength(250)]
        public string Level { get; set; }
        public string Description { get; set; }
    }
}
