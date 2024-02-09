using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TransportTerminal.DAL.DALModels
{
    public class BigVehicle : Vehicle
    {
        [JsonIgnore]
        const string bigVehicle = "BigVehicle";

        [JsonIgnore]
        public override string Type { get => bigVehicle; }
    }
}
