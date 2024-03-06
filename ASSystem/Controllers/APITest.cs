using ASSystem.Dtos;
using ASSystem.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APITest : ControllerBase
    {
        private readonly AccommodationSearchSystemContext _context;

        private readonly IMapper _mapper;
        public APITest(AccommodationSearchSystemContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<RoomResponseTest> Get()
        {
            var list = _context.Rooms.ToList();

            //
            return Ok(_mapper.Map<List<RoomResponseTest>>(list));
        }
    }
}
