namespace AddEditMetronic8.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int CountryID { get; set; }
        public int StateID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
