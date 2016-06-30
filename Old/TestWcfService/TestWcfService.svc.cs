using WCFTestContract;
using ContractImplementation;

namespace TestWcfService
{
    public class TestService : IEmployeeIOperation
    {
        readonly IEmployeeIOperation _eop;
        public TestService()
        {
            _eop = new EmpService();
        }
        public int AddEmployeeDetails(Employee emp)
        {
            return _eop.AddEmployeeDetails(emp);
        }

        public Employee[] GetEmployeeDetails()
        {
            return _eop.GetEmployeeDetails();
        }
        public int DeleteEmp(Employee emp)
        {
            return _eop.DeleteEmp(emp);
        }
    }
}

