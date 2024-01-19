using PostgreSQL_CRUD.Common;

namespace PostgreSQL_CRUD.Features.StudentFeatures.Dtos
{
    public class GetStudentListResponse : ResponseStatus
    {
        public List<StudentResponse> Students { get; set; } = new List<StudentResponse>();
        public int TotalItems { get; set; }
    }
    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
