using AgriInvestment.Core.Models;
using Dapper;
using Jilipe.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jilipe.DataAccess.SQLDapper
{
    public class ProductCategoryDataSource
    {
        public List<ProductCategory> GetAll()
        {
            return (List<ProductCategory>)DapperORM.ReturnList<ProductCategory>("GetProductCategories");
        }

        public ProductCategory GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (ProductCategory)DapperORM.ReturnSingle<ProductCategory>("GetProductCategory", spParams);
        }

        public void AddEdit(ProductCategory productCategory, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", productCategory.Id);
            spParams.Add("Name", productCategory.Name);
            spParams.Add("Description", productCategory.Description);
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
