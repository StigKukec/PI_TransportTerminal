using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TransportTerminal.DAL.DALModels;

namespace TransportTerminal.DAL.Repositories
{
    internal class Files : IFiles
    {
        private static readonly string direktorij = Directory.GetCurrentDirectory();
        private static string bigVehiclesFile = Path.Join(direktorij, @$"..\TransportTerminal.DAL\Resources\bigVehicles.json");
        private static string smallVehiclesFile = Path.Join(direktorij, @$"..\TransportTerminal.DAL\Resources\smallVehicles.json");

 
        public List<BigVehicle> GetBigVehicles()
        {
            List<BigVehicle> data;
            try
            {
                string jsonData = File.ReadAllText(bigVehiclesFile);
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    data = JsonSerializer.Deserialize<List<BigVehicle>>(jsonData);
                }
                else
                {
                    data = new List<BigVehicle>();
                }
            }
            catch (FileNotFoundException)
            {
                return new List<BigVehicle>();
            }
            return data;
        }
        public List<SmallVehicle> GetSmallVehicles()
        {
            List<SmallVehicle> data;
            try
            {
                string jsonData = File.ReadAllText(smallVehiclesFile);
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    data = JsonSerializer.Deserialize<List<SmallVehicle>>(jsonData);
                }
                else
                {
                    data = new List<SmallVehicle>();
                }
            }
            catch (FileNotFoundException)
            {
                return new List<SmallVehicle>();
            }
            return data;
        }

        public void SaveData(Vehicle data)
        {

            if (data.Type.Equals(nameof(BigVehicle)))
            {
                List<Vehicle> vehicles = new(GetBigVehicles());
                SaveVehicleToFile(data, bigVehiclesFile, vehicles);
            }
            if (data.Type.Equals(nameof(SmallVehicle)))
            {
                List<Vehicle> vehicles = new(GetSmallVehicles());
                SaveVehicleToFile(data, smallVehiclesFile, vehicles);
            }
        }

        private static void SaveVehicleToFile(Vehicle data, string filePath, List<Vehicle> vehicles)
        {
            List<Vehicle> dataList;
            string fileContent = File.ReadAllText(filePath);
            if (!string.IsNullOrWhiteSpace(fileContent))
            {
                dataList = new(vehicles)
                {
                    data
                };
            }
            else
            {
                dataList = new()
                {
                    data
                };
            }
            string jsonData = JsonSerializer.Serialize(dataList);
            File.WriteAllText(filePath, jsonData);
        }

        public void DeleteAll()
        {
            string data = "";
            File.WriteAllText(smallVehiclesFile,data);
            File.WriteAllText(bigVehiclesFile,data);

        }
    }
}
