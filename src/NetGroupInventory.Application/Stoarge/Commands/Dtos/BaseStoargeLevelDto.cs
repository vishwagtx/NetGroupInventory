using System.ComponentModel.DataAnnotations;

namespace NetGroupInventory.Application.Stoarge.Commands.Dtos
{
    public abstract class BaseStoargeLevelDto
    {
        [Required]
        [StringLength(250)]
        public string Level { get; set; }
        public string Description { get; set; }
    }
}
