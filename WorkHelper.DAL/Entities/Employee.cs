namespace WorkHelper.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public override string ToString() =>
            $"Employee: Id={Id}, FirstName='{FirstName}', MiddleName='{MiddleName}', LastName='{LastName}'";
    }
}
