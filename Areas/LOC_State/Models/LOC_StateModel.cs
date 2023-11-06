using System.ComponentModel.DataAnnotations;

namespace AddEditMetronic8.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }
        [Required]
        public int? CountryID { get; set; }
        [Required]
        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public int? UserID { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class Statedropdown
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
    }
}
