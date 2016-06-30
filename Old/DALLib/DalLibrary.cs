using System.Collections.Generic;
using System.Data.SqlClient;
using FrameWork;

namespace DALLib
{
    public class EmployeeDal
    {
        public int EmpId { get; set; }

        public string EmpName { get; set; }

        public string Dept { get; set; }

        public int ScrumNo { get; set; }
    }

    public static class CDalFactory
{    
    public static IDal DalFactory(string cnnStr)
    {
        return new MyDal(cnnStr);
    }
}
    public interface IDal
    {
        EmployeeDal[] GetEmployeeDetails();
        int AddEmployeeDetails(EmployeeDal emp);
        int DeleteEmp(EmployeeDal emp);
    }

    internal class MyDal : IDal
    {
        private readonly IWcfFramework _framework;
                
      
        public  MyDal(string cnnStr)
    {
        _framework = FrameWorkFactory.GetFrameworkObj(cnnStr);         
    }

        public EmployeeDal[] GetEmployeeDetails()
        {
            List<EmployeeDal> list = new List<EmployeeDal>();
            SqlDataReader reader = (SqlDataReader)_framework.PerformDb(0, "select * from TestEmpTable");
            while (reader.Read())
            {
                EmployeeDal item = new EmployeeDal
                {
                    EmpId = int.Parse(reader[0].ToString()),
                    EmpName = reader[1].ToString(),
                    Dept = reader[2].ToString(),
                    ScrumNo = int.Parse(reader[3].ToString())
                };
                list.Add(item);
            }
            reader.Close();
            return list.ToArray();
        }

        public int AddEmployeeDetails(EmployeeDal emp)
        {
            string str = $"insert into TestEmpTable values({emp.EmpId},'{emp.EmpName}','{emp.Dept}',{emp.ScrumNo})";
            return int.Parse(_framework.PerformDb(1, str).ToString());
        }

       public int DeleteEmp(EmployeeDal emp)
        {
            string str = $"delete from TestEmpTable where EmpId={emp.EmpId}";
            return int.Parse(_framework.PerformDb(1, str).ToString());
        }
    }
}
