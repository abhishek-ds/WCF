using System.ServiceModel;
using System.Runtime.Serialization;

namespace WCFTestContract
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmpId { get; set; }

        [DataMember]
        public string EmpName { get; set; }

        [DataMember]
        public string Dept { get; set; }

        [DataMember]
        public int ScrumNo { get; set; }

    }


    [ServiceContract]
    public interface IEmployeeIOperation
    {
        [OperationContract]
        int AddEmployeeDetails(Employee emp);

        [OperationContract]
        Employee[] GetEmployeeDetails();

        [OperationContract]
        int DeleteEmp(Employee emp);
    }
}
