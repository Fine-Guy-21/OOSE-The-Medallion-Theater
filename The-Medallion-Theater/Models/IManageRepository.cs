using Microsoft.EntityFrameworkCore;

namespace The_Medallion_Theater.Models
{
    public interface IManageRepository
    {
        public List<Production> GetProductions(); 
        public Production GetProductionByID(string id);
        public Production SaveProduction(Production production);
        public Production UpdateProduction(Production production); 
        public void DeleteProdution(Production production);


    }
}
