namespace AddEditMetronic8.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }
        public int CountryID { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
    public class Statedropdown
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
    }
}
