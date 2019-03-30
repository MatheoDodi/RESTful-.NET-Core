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
        public async  Task<IHttpActionResult> Get()
        {
            try
            {

                var result = await _repository.GetAllCampsAsync();

                // Mapping
                var mappedResult = _mapper.Map<IEnumerable <CampModel>>(result);


                return Ok(mappedResult);
            }
            catch (Exception ex)
            {
                //TODO Add Logging
                return InternalServerError();
            }
        }
    }
}