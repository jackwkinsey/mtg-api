using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mtg_api.Data;
using mtg_api.Models;

namespace mtg_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CardsController : ControllerBase
  {
    private readonly CardContext _context;
    public CardsController(CardContext context)
    {
      _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Card>> Get()
    {
      return Ok(_context.Cards);
    }

    [HttpGet("{id}")]
    public ActionResult<Card> Get(string id)
    {
      var card = _context.Cards.SingleOrDefault(c =>
        (c.SetCode + c.CollectionNumber).ToUpper() == id.ToUpper()
      );

      if (card == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(card);
      }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Card card)
    {
      var id = (card.SetCode + card.CollectionNumber).ToUpper();
      var found = _context.Cards.SingleOrDefault(c =>
        (c.SetCode + c.CollectionNumber).ToUpper() == id
      );

      if (found != null)
      {
        return BadRequest("Card already exists!");
      }
      else
      {
        _context.Cards.Add(card);
        _context.SaveChanges();
      }
      return Ok("Card added!");
    }

    [HttpPut("{id}")]
    public ActionResult Put(string id, [FromBody] Card card)
    {
      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
      return Ok();
    }
  }
}