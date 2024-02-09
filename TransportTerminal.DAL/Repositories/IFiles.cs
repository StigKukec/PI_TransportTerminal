using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportTerminal.DAL.DALModels;

namespace TransportTerminal.DAL.Repositories
{
    public interface IFiles
    {
        void DeleteAll();
        List<BigVehicle> GetBigVehicles();
        List<SmallVehicle> GetSmallVehicles();
        void SaveData(Vehicle data);
    }
}
