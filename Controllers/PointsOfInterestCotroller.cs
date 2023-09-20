using DLS_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DLS_WebAPI.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestCotroller : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointOfInterests);
        }

        [HttpGet("{pointofinterestid}")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(
            int cityId, int pointofinterestid)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault
                (x=> x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(c => c.Id == pointofinterestid);
            if (pointOfInterest == null)
            {
                    
                return NotFound();

            }
            return Ok(pointOfInterest);


        }
    }
}
