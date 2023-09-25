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

        [HttpGet("{pointofinterestid}", Name ="GetPointOfInterest")]
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


        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int cityId, PointOfInterestCreationDto pointOfInterestCreationDto)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            var city = CityDataStore.Current.Cities.FirstOrDefault (x => x.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            //demo purpose - To be improved
            var maxpointOfInterestId = CityDataStore.Current.Cities.
                SelectMany(city => city.PointOfInterests).Max(x => x.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxpointOfInterestId,
                Name = pointOfInterestCreationDto.Name,
                Description = pointOfInterestCreationDto.Description
            };


            city.PointOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInteresId = finalPointOfInterest.Id
                }, finalPointOfInterest
                );
        }

        [HttpPut("{pointOfInterestId}")]
        public  ActionResult UpdatePointOfInterest(int cityId,
            int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterestForUpdateDto)
        { 
            //if (ModelState.IsValid) 
            //{ 
            //    return BadRequest(); 
            //}

            var city = CityDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            //find point of interest

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(
                c => c.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null)
            {
                    return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterestForUpdateDto.Name;
            pointOfInterestFromStore.Description = pointOfInterestForUpdateDto.Description; 

            return NoContent();
        }


        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = CityDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterests
                .FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointOfInterests.Remove(pointOfInterestFromStore);
            return NoContent();
        }

    }
}
