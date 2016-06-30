using System.Linq;
using WCFTestContract;
using DALLib;
using System.Configuration;

namespace ContractImplementation
{
    public class EmpService : IEmployeeIOperation
    {
        readonly IDal _dal;
        public EmpService()
        {
            var constring = ConfigurationManager.ConnectionStrings["DbStr"].ConnectionString;
            _dal = CDalFactory.DalFactory(constring);
        }
        
        public Employee[] GetEmployeeDetails()
        {
            EmployeeDal[] empList = _dal.GetEmployeeDetails();
            Employee[] empDtList = (from n in empList select new Employee { EmpId = n.EmpId, EmpName = n.EmpName, Dept = n.Dept, ScrumNo = n.ScrumNo }).ToArray();
            return empDtList;
        }


        public int AddEmployeeDetails(Employee emp)
        {            
            return _dal.AddEmployeeDetails(new EmployeeDal { EmpId = emp.EmpId, EmpName = emp.EmpName, Dept = emp.Dept, ScrumNo = emp.ScrumNo });
        }

        public int DeleteEmp(Employee emp)
        {
            return _dal.DeleteEmp(new EmployeeDal { EmpId = emp.EmpId });
        }
    }
}
