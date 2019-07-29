using AgriInvestment.Core.Models;
using AgriInvestment.Core.ViewModels;
using Dapper;
using Jilipe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQLDapper
{
    public class InvestmentProductDataSource
    {
        public List<InvestmentProductManagerViewModel> GetAll()
        {
            List<InvestmentProductManagerViewModel> var = (List<InvestmentProductManagerViewModel>)DapperORM.ReturnList<InvestmentProductManagerViewModel>("GetProducts");
            foreach(InvestmentProductManagerViewModel prod in var)
            {
                prod.InvestmentCategory = new InvestmentCategory
                {
                    Id = prod.ProductCategoryId,
                    Name = prod.ProductCategoryName,
                    Description = prod.ProductCategoryName
                };
            }
            return var;
        }

        public InvestmentProduct GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (InvestmentProduct)DapperORM.ReturnSingle<InvestmentProduct>("GetProduct", spParams);
        }

        public void AddEdit(InvestmentProduct investmentProduct, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", investmentProduct.Id);
            spParams.Add("Name", investmentProduct.Name);
            spParams.Add("Description", investmentProduct.Description);
            spParams.Add("ProductCategoryId", investmentProduct.ProductCategoryId);
            spParams.Add("InvestmentPeriod", investmentProduct.InvestmentPeriod);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("AddEditProduct", spParams);
        }

        public void Delete(int Id, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("DeleteProduct", spParams);
        }
    }
}
