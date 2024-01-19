using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreSQL_CRUD.Common;
using PostgreSQL_CRUD.Features.StudentFeatures.Dtos;

namespace PostgreSQL_CRUD.Features.StudentFeatures
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _repo;

        public StudentsController(IStudentService repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequest req)
        {
            try
            {
                var response = await _repo.CreateStudent(req);
                return StatusCode(response.StatusCode, response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentDetailById(int id)
        {
            try
            {
                var response = await _repo.GetStudentDetailById(id);
                return StatusCode(response.StatusCode,response);    
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetStudentList([FromQuery]PaginationRequest req)
        {
            try
            {
                var response = await _repo.GetStudentList(req);
                return StatusCode(response.StatusCode, response);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser()
        {
            try
            {
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
