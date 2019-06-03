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
    public class investmentCycleDataSource
    {
        public List<InvestmentCycle> GetAll()
        {
            return (List<InvestmentCycle>)DapperORM.ReturnList<InvestmentCycle>("GetInvestmentCycles");
        }

        public List<InvestmentCycleManagerViewModel> GetAllVm()
        {
            return (List<InvestmentCycleManagerViewModel>)DapperORM.ReturnList<InvestmentCycleManagerViewModel>("GetInvestmentCycles");
        }

        public InvestmentCycle GetById(int Id)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);

            return (InvestmentCycle)DapperORM.ReturnSingle<InvestmentCycle>("GetInvestmentCycle", spParams);
        }

        public void AddEdit(InvestmentCycle investmentCycle, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", investmentCycle.Id);
            spParams.Add("FromDate", investmentCycle.FromDate);
            spParams.Add("ProductId", investmentCycle.ProductId);
            spParams.Add("TargetAmount", investmentCycle.TargetAmount);
            spParams.Add("MinimumAmount", investmentCycle.MinimumAmount);
            spParams.Add("MaximumAmount", investmentCycle.MaximumAmount);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("AddEditInvestmentCycle", spParams);
        }

        public void Delete(int Id, User user)
        {
            DynamicParameters spParams = new DynamicParameters();

            spParams.Add("Id", Id);
            spParams.Add("UserId", user.Id);

            DapperORM.ExecuteWithoutReturn("DeleteInvestmentCycle", spParams);
        }
    }
}
