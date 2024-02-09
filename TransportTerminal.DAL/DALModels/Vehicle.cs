using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TransportTerminal.DAL.DALModels
{
    public abstract class Vehicle
    {
        private int gas; 
        private int battery;
        private readonly long _id;
        public Vehicle()
        {
            Random random = new();
            ++_id;
            gas = random.Next(0, 100);
            battery = random.Next(0, 100);
        }
        [JsonPropertyName(name:"id")]
        public long Id { get => _id; }

        [JsonPropertyName(name: "ticketPrice")]
        public virtual double TicketPrice { get; set; }

        [JsonPropertyName(name: "gas")]
        public int Gas{ get {  return gas; } }

        [JsonPropertyName(name: "battery")]
        public int Battery { get {  return battery; } }

        [JsonPropertyName(name: "type")]
        public virtual string Type { get; set; }
    }
}
