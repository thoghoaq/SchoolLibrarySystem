using BusinessObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO : BaseDAL
    {
        //Singleton Pattern
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public User GetUserByEmail(string email)
        {
            User user = null;
            IDataReader dataReader = null;
            string SQL = "select UserId, Name, Email, Password, Role, Status from [User] where Email = @Email";
            try
            {
                var param = dataProvider.CreateParameter("@Email", 125, email, DbType.String);
                dataReader = dataProvider.GetDataReader(SQL, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    user = new User
                    {
                        UserID = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Email = dataReader.GetString(2),
                        Password = dataReader.GetString(3),
                        Role = dataReader.GetString(4),
                        Status = dataReader.GetString(5)
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                dataReader.Close();
                CloseConnection();
            }
            return user;
        }
    }
}
