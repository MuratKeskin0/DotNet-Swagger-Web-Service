using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MinApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        // GET: api/<markaController>
        [HttpGet]
        public IEnumerable<Marka> Get()
        {
            Marka o = new Marka();
            return o.genel_liste();
        }


        // GET api/<markaController>
        [HttpGet("{id:int}")]
        public Marka Get( int id)
        {
            Marka o = new Marka();
            return o.getmarkaById(id);
        }

        // POST api/<markaController>
        [HttpPost]
        public int Post(Marka o)
        {
            return o.kaydet();
        }

        // PUT api/<markaController>
        [HttpPut]
        public int Put(Marka o)
        {
            return o.guncelle();
        }
        // DELETE api/<markaController>
        [HttpDelete]
        public int Delete(int id)
        {
            Marka o = new Marka();
            o.marka_id = id;
            return o.sil();
        }

    }
}
