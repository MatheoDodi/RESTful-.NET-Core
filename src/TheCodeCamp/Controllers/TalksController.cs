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
  [System.Web.Http.RoutePrefix("api/camps/{moniker}/talks")]
  public class TalksController : ApiController
  {
    private readonly ICampRepository _repository;
    private readonly IMapper _mapper;

    public TalksController(ICampRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    [System.Web.Http.Route("")]
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

    [System.Web.Http.Route("{talkId:int}", Name = "GetTalk" )]
    public async Task<IHttpActionResult> Get(string moniker, int talkId, bool includeSpeakers = false)
    {
      try
      {
        var result = await _repository.GetTalkByMonikerAsync(moniker, talkId, includeSpeakers);

        return Ok(_mapper.Map<TalkModel>(result));
      }
      catch
      {
        return InternalServerError();
      }
    }

    //POST : talk
    [System.Web.Http.Route()]
    public async Task<IHttpActionResult> Post(string moniker, TalkModel talkModel)
    {
      try
      {
        var camp = await _repository.GetCampAsync(moniker);

        var talk = _mapper.Map<Talk>(talkModel);
        talk.Camp = camp;

        _repository.AddTalk(talk);

        bool successfulChanges = await _repository.SaveChangesAsync();

        if (successfulChanges)
        {
          return CreatedAtRoute("GetTalk", new { moniker = moniker, talkId = talk.TalkId }, _mapper.Map<TalkModel>(talk));
        }
        else
        {
          return InternalServerError();
        }
      }
      catch
      {
        return InternalServerError();
      }
    }
  }
}