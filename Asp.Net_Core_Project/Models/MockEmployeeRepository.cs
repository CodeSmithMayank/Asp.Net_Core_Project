namespace Asp.Net_Core_Project.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        
        private List<Employee> _employeelist;
        public MockEmployeeRepository()
        {
            _employeelist = new List<Employee>()
            {
                new Employee() {Id=10,Name="Mayank",Email="abc@gmail.com",Department="D1"},
                new Employee() {Id=21,Name="Omkara",Email="xyz@gmail.com",Department="D2"},
                new Employee() {Id=66,Name="Shivayee",Email="mno@gmail.com",Department="D3"}

            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeelist.Where(S=>S.Id == id).FirstOrDefault();
        }

        public Employee GetAllEmployeData()
        {
            return _employeelist.FirstOrDefault();
        }
    }
}
