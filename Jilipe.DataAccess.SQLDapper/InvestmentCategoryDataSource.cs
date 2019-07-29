using AgriInvestment.Core.Models;
using Dapper;
using Jilipe.Core.Models;
using Jilipe.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQLDapper
{
    public class InvestmentCategoryDataSource
    {
        public List<InvestmentCategoryManagerViewModel> GetAll()
        {
            return (List<InvestmentCategoryManagerViewModel>)DapperORM.ReturnList<InvestmentCategoryManagerViewModel>("GetProductCategories");
        }

        public InvestmentCategory GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (InvestmentCategory)DapperORM.ReturnSingle<InvestmentCategory>("GetProductCategory", spParams);
        }

        public void AddEdit(InvestmentCategory investmentCategory, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", investmentCategory.Id);
            spParams.Add("Name", investmentCategory.Name);
            spParams.Add("Description", investmentCategory.Description);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("AddEditProductCategory", spParams);
        }

        public void Delete(int Id, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("DeleteProductCategory", spParams);
        }
    }
}
