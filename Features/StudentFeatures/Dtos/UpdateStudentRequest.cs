namespace PostgreSQL_CRUD.Features.StudentFeatures.Dtos
{
    public class UpdateStudentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
