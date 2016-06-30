using System.Data;
using System.Data.SqlClient;

namespace FrameWork
{
    public static class FrameWorkFactory
    {
        public static IWcfFramework GetFrameworkObj(string cnnStr)
        {
            return new MyFramework(cnnStr);
        }

    }
    
    

    public interface IWcfFramework
    {
        object PerformDb(int choice, string query);
    }

    internal class MyFramework : IWcfFramework
    {        
         
    private readonly string _cnnStr;

    
    public MyFramework(string cnnStr)
    {
        _cnnStr = cnnStr;
    }

    public object PerformDb(int cchoice, string query)
    {
        int num = 0;
        var choice = (SqlChoice)cchoice;
        SqlConnection connection = new SqlConnection {
            ConnectionString = _cnnStr
        };
        SqlCommand command = new SqlCommand {
            CommandText = query,
            Connection = connection
        };
        connection.Open();
        switch (choice)
        {
            case SqlChoice.Dql:
                return command.ExecuteReader(CommandBehavior.CloseConnection);

            case SqlChoice.Dml:
                num = command.ExecuteNonQuery();
                break;

            case SqlChoice.Scalar:
                num = (int) command.ExecuteScalar();
                break;
        }
        connection.Close();
        return num;
    }
}
      

    public enum SqlChoice
    {
        Dql,
        Dml,
        Scalar
    }
}
