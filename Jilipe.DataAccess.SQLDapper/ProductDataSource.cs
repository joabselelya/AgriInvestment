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
    public class ProductDataSource
    {
        public List<Product> GetAll()
        {
            return (List<Product>)DapperORM.ReturnList<Product>("GetProducts");
        }

        public List<ProductManagerViewModel> GetAllVm()
        {
            return (List<ProductManagerViewModel>)DapperORM.ReturnList<ProductManagerViewModel>("GetProducts");
        }

        public Product GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (Product)DapperORM.ReturnSingle<Product>("GetProduct", spParams);
        }

        public void AddEdit(Product product, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", product.Id);
            spParams.Add("Name", product.Name);
            spParams.Add("Description", product.Description);
            spParams.Add("ProductCategoryId", product.ProductCategoryId);
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
