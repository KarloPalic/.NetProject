using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class RepositoryFactory
    {
        public IRepository GetRepository(string repositoryType)
        {
            if (repositoryType.Equals("API", StringComparison.OrdinalIgnoreCase))
            {
                return new API();
            }
            else if (repositoryType.Equals("JSON", StringComparison.OrdinalIgnoreCase))
            {
                return new JSON();
            }
            else
            {
                throw new ArgumentException("Invalid repository type");
            }
        }

    }
}
