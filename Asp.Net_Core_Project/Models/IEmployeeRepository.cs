namespace Asp.Net_Core_Project.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
    }
}
