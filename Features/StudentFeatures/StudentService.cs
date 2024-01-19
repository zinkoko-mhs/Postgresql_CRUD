using Microsoft.EntityFrameworkCore;
using PostgreSQL_CRUD.Common;
using PostgreSQL_CRUD.Context;
using PostgreSQL_CRUD.Features.StudentFeatures.Dtos;
using PostgreSQL_CRUD.Models;

namespace PostgreSQL_CRUD.Features.StudentFeatures
{
    public interface IStudentService
    {
        Task<ResponseStatus> CreateStudent(CreateStudentRequest req);
        Task<GetStudentDetailByIdResponse> GetStudentDetailById(int id);
        Task<GetStudentListResponse> GetStudentList(PaginationRequest req);
    }

    public class StudentService : IStudentService
    {
        private readonly DatabaseContext _context;

        public StudentService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ResponseStatus> CreateStudent(CreateStudentRequest req)
        {
            try
            {
                var student = new Student
                {
                    Name = req.Name,
                    Email = req.Email,
                    DateOfBirth = req.DateOfBirth,
                    CreatedDate = DateTime.UtcNow,
                    CreatedBy = 1,
                    IsActive = true
                };
                _context.Student.Add(student);
                await _context.SaveChangesAsync();

                return new ResponseStatus
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Success",
                    Ref = student.Id.ToString()
                };
            }
            catch (Exception ex)
            {
                return new ResponseStatus
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message,
                };
            }
        }
    
        public async Task<GetStudentDetailByIdResponse> GetStudentDetailById(int id)
        {
            try
            {
                var resposne = await _context.Student.Where(x => x.IsActive == true && x.Id == id)
                               .AsNoTracking().Select(x => new GetStudentDetailByIdResponse
                               {
                                   Id = x.Id,
                                   Name = x.Name,
                                   DateOfBirth = x.DateOfBirth,
                                   StatusCode = StatusCodes.Status200OK,
                                   Message = "Success"
                               }).FirstOrDefaultAsync();

                if(resposne == null)
                {
                    return new GetStudentDetailByIdResponse
                    {
                        StatusCode = StatusCodes.Status204NoContent,
                        Message = "Student Does Not Exist"
                    };
                }

                return resposne;
            }
            catch(Exception e)
            {
                return new GetStudentDetailByIdResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                };
            }
        }
    
        public async Task<GetStudentListResponse> GetStudentList(PaginationRequest req)
        {
            try
            {
                var response = new GetStudentListResponse();

                response.Students = await _context.Student.Where(x=> x.IsActive == true)
                                    .Select(x => new StudentResponse
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Email = x.Email,
                                        DateOfBirth = x.DateOfBirth
                                    }).Skip((req.PageNumber-1)*req.PageSize).Take(req.PageSize).ToListAsync();

                response.TotalItems = await _context.Student.Where(x => x.IsActive == true).CountAsync();
                response.StatusCode = StatusCodes.Status200OK;
                response.Message = "Success";
                return response;
            }
            catch(Exception e)
            {
                return new GetStudentListResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                };
            }
        }
    }
}
