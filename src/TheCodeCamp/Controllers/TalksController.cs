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
  public class TalksController : ApiController
  {
    private readonly ICampRepository _repository;
    private readonly IMapper _mapper;

    public TalksController(ICampRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [System.Web.Http.Route("{moniker}/talks")]
    public async Task<IHttpActionResult> Get(string moniker, bool includeSpeakers = false)
    {
      try
      {
        var result = await _repository.GetTalksByMonikerAsync(moniker, includeSpeakers);

        return Ok(_mapper.Map<IEnumerable<TalkModel>>(result));
      }
      catch
      {
        return InternalServerError();
      }
    }
  }
}