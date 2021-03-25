using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VSTrain.Core.Features;
using VSTrain.Core.Features.Courses.Commands.CreateCourse;
using VSTrain.Core.Features.Courses.Commands.UpdateCourse;

namespace VSTrain.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly IMediator mediatr;

        public CourseController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet(Name = "GetAllCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<CourseVM>>> GetAllEvents()
        {
            var dtos = await mediatr.Send(new GetCoursesListQuery());
            return Ok(dtos);
        }
        
        [HttpGet("{id}", Name = "GetCOurseById")]
        public async Task<ActionResult<CourseVM>> GetEventById(int id)
        {
            var getEventDetailQuery = new GetCourseQuery() { Id = id };
            return Ok(await mediatr.Send(getEventDetailQuery));
        }
        [HttpPost(Name = "AddCourse")]
        public async Task<ActionResult<CreateCourseCommandResponse>> Create([FromBody] CreateCourseCommand createCourseCommand)
        {
            var response = await mediatr.Send(createCourseCommand);
            return Ok(response); 
        }

        [HttpPut(Name = "UpdateCourse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCourseCommand updateCourseCommand)
        {
            await mediatr.Send(updateCourseCommand);
            return NoContent();
        }        
        
        
    }
       
}