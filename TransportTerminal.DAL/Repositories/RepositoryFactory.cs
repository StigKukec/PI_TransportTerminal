using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportTerminal.DAL.Repositories
{
    public class RepositoryFactory
    {
        private static RepositoryFactory repositoryFactory;
        private RepositoryFactory() { }
        public Lazy<IIncomeAnalysis> IncomeAnalysis => new(() => new IncomeAnalysis());
        public Lazy<IFiles> Files => new(() => new Files());
        public static  RepositoryFactory Instance { get => repositoryFactory ??= new RepositoryFactory(); }
    }
}
