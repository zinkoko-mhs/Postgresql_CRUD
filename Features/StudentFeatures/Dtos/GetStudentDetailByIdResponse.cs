using PostgreSQL_CRUD.Common;

namespace PostgreSQL_CRUD.Features.StudentFeatures.Dtos
{
    public class GetStudentDetailByIdResponse : ResponseStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
