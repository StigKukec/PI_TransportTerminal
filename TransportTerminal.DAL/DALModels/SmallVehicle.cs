using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TransportTerminal.DAL.DALModels
{
    public class SmallVehicle : Vehicle
    {
        [JsonIgnore]
        const string smallVehicle = "SmallVehicle";

        [JsonIgnore]
        public override string Type { get => smallVehicle; }
    }
}
