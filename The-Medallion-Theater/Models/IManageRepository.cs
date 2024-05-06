using Microsoft.EntityFrameworkCore;

namespace The_Medallion_Theater.Models
{
    public interface IManageRepository
    {
        public Patron GetUserById(string id); 
        public List<Production> GetProductions(); 
        public Production GetProductionByID(string id);
        public Production SaveProduction(Production production);
        public Production UpdateProduction(Production production); 
        public void DeleteProdution(Production production);

        public List<Performance> GetPerformances();
        public Performance GetPerformanceByID(string id);
        public Performance SavePerformance(Performance performance);
        public Performance UpdatePerformance(Performance performance);
        public void DeletePerformance(Performance performance);

        public Ticket GenerateTicket(Ticket ticket);
        public List<Ticket> ShowMyTickets(string id);
        

    }
}
