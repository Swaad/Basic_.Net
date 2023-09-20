namespace DLS_WebAPI.Models
{
    public class CityDataStore
    {
        public List<CityDto> Cities {  get; set; }

        public static CityDataStore Current { get; set; } = new CityDataStore();
        public CityDataStore() 
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "CityDto_name1",
                    Description = "CityDto_Description1",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "PointOfInterestDto_asd1",
                            Description = "PointOfInterestDto_qwe1"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "PointOfInterestDto_asd2",
                            Description = "PointOfInterestDto_qwe2"
                        }
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "CityDto_Name2",
                    Description = "CityDto_Description2"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "CityDto_Name3",
                    Description = "CityDto_Description3"
                }
            };
        }


    }
}
