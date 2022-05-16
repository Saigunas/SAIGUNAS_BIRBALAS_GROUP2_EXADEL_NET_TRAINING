using Newtonsoft.Json;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        var path = "..\\..\\..\\inhabitants.json";
        string jsonInhabitants = File.ReadAllText(path);

        var inhabitantList = JsonConvert.DeserializeObject<List<Inhabitant>>(jsonInhabitants);
        if (inhabitantList == null)
        {
            Console.WriteLine("No inhabitants found");
            return;
        }

        path = "..\\..\\..\\cities.json";
        string jsonCities = File.ReadAllText(path);

        var citiesList = JsonConvert.DeserializeObject<List<City>>(jsonCities);
        if(citiesList == null)
        {
            Console.WriteLine("No cities found");
            return;
        }

        foreach (var inhabitant in inhabitantList)
        {
            var inhabitantsCity = citiesList.Find(c => c.CityName == inhabitant.CityName);
            if (inhabitantsCity == null)
            {
                Console.WriteLine($"No city found for the inhabitant {inhabitant.Name}");
                continue;
            }

            if (inhabitantsCity.Population < 50000)
            {
                continue;
            }

            string employability = "";
            if (inhabitant.Age <= 15)
            {
                employability = "is not employable";
            }
            else if (inhabitant.Age >= 16 && inhabitant.Age <= 64)
            {
                employability = "is employable";
            }
            else if (inhabitant.Age >= 65 && inhabitant.Age <= 100)
            {
                employability = "is not employable";
            }

            Console.WriteLine($"{inhabitant.Name} {inhabitant.Surname} {employability}");
        }
    }

    public class Inhabitant
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("city")]
        public string CityName { get; set; }
    }

    public class City
    {
        [JsonProperty("city")]
        public string CityName { get; set; }

        [JsonProperty("population")]
        public int Population { get; set; }
    }
}