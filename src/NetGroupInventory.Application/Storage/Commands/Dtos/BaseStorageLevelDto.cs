using System.ComponentModel.DataAnnotations;

namespace NetGroupInventory.Application.Storage.Commands.Dtos
{
    public abstract class BaseStorageLevelDto
    {
        [Required]
        [StringLength(250)]
        public string Level { get; set; }
        public string Description { get; set; }
    }
}
