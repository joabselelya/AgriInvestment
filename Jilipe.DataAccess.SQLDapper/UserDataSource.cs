using Dapper;
using Jilipe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQLDapper
{
    public class UserDataSource
    {
        public List<User> GetAll()
        {
            return (List<User>)DapperORM.ReturnList<User>("GetProducts");
        }

        public User GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (User)DapperORM.ReturnSingle<User>("GetUser", spParams);
        }

        public void AddEdit(User theUser)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", theUser.Id);
            spParams.Add("UserName", theUser.UserName);
            spParams.Add("FirstName", theUser.FirstName);
            spParams.Add("MiddleName", theUser.MiddleName);
            spParams.Add("Surname", theUser.Surname);

            DapperORM.ExecuteWithoutReturn("AddEditUser", spParams);
        }

        public void Delete(int Id, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("DeleteUser", spParams);
        }
    }
}
