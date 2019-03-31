using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TheCodeCamp.Data;
using TheCodeCamp.Models;

namespace TheCodeCamp.Controllers
{
    [System.Web.Http.RoutePrefix("api/camps")]
    public class CampsController : ApiController
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: Camps
        [System.Web.Http.Route()]
        public async  Task<IHttpActionResult> Get(bool includeTalks = false)
        {
            try
            {

                var result = await _repository.GetAllCampsAsync(includeTalks);

                // Mapping
                var mappedResult = _mapper.Map<IEnumerable <CampModel>>(result);


                return Ok(mappedResult);
            }
            catch
            {
                //TODO Add Logging
                return InternalServerError();
            }
        }


      [System.Web.Http.Route("{moniker}", Name = "GetCamp")]  
      public async Task<IHttpActionResult> Get(string moniker, bool includeTalks = false)
      {
        try
      {
        var result = await _repository.GetCampAsync(moniker, includeTalks);
        if (result == null)
        {
          return NotFound();
        }

        return Ok(_mapper.Map<CampModel>(result));

      } catch (Exception ex)
      {
        return InternalServerError(ex);
      }
      }

      [System.Web.Http.Route("searchByDate/{eventDate:DateTime}")]
      [System.Web.Http.HttpGet]
      public async Task<IHttpActionResult> SearchByEventDate(DateTime eventDate, bool includeTalks = false)
    {
      try
      {
        var result = await _repository.GetAllCampsByEventDate(eventDate, includeTalks);

        return Ok(_mapper.Map<IEnumerable <CampModel>>(result));
      }
      catch (Exception ex)
      {
        return InternalServerError(ex);
      }
    }

    // POST 
    [System.Web.Http.Route()]
    public async Task<IHttpActionResult> Post(CampModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          if (await _repository.GetCampAsync(model.Moniker) != null)
          {
            ModelState.AddModelError("Moniker", "Moniker in Use");
            return BadRequest();
          }

          var camp = _mapper.Map<Camp>(model);

          _repository.AddCamp(camp);

          if (await _repository.SaveChangesAsync())
          {
            var newModel = _mapper.Map<CampModel>(camp);

            return CreatedAtRoute("GetCamp", new { moniker = newModel.Moniker }, newModel);
          }
        }
      }
      catch
      {
        return InternalServerError();
      }

      return BadRequest();
    }
  }
}