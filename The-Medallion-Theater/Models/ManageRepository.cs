namespace The_Medallion_Theater.Models
{
    public class ManageRepository : IManageRepository
    {

        private readonly MyDbContext myDbContext;

        public int ProductionID { get; private set; }

        public ManageRepository(MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
        }


        public List<Production> GetProductions()=> myDbContext.Productions.ToList();
        
        public Production GetProductionByID(string id)
        {
            Production pr = myDbContext.Productions.Where(o => o.ProductionId == id).FirstOrDefault();
            return pr; 
        }



        public Production SaveProduction(Production production)
        {
            myDbContext.Productions.Add(production);
            myDbContext.SaveChanges();
            return production;
        }

        public Production UpdateProduction(Production production)
        {
            myDbContext.Productions.Update(production);
            myDbContext.SaveChanges();
            return production;
        }

        public void DeleteProdution(Production production)
        {
            myDbContext.Productions.Remove(production);
            myDbContext.SaveChanges();
        }


        public List<Performance> GetPerformances() => myDbContext.Performances.ToList();

        public Performance GetPerformanceByID(string id)
        {
            Performance pr = myDbContext.Performances.Where(o => o.PerformanceID== id).FirstOrDefault();
            return pr;
        }
        
        public Performance SavePerformance(Performance performance)
        {
            myDbContext.Performances.Add(performance);
            myDbContext.SaveChanges();
            return performance;
        }

        public Performance UpdatePerformance (Performance performance)
        {
            myDbContext.Performances.Update(performance);
            myDbContext.SaveChanges();
            return performance;
        }        

        public void DeletePerformance(Performance performance)
        {
            myDbContext.Performances.Remove(performance);
            myDbContext.SaveChanges();
        }
        




    }
}
