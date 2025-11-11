namespace GotSeries.Api.Service.DTOS.Response
{
    public class LocationDto
    {
            public int id { get; set; }
            public Kingdom kingdom { get; set; }
            public string name { get; set; }
            public string summary { get; set; }
            public string url { get; set; }
        }

        public class Kingdom
        {
            public int id { get; set; }
            public string name { get; set; }
            public string summary { get; set; }
            public string url { get; set; }
        }

    }

