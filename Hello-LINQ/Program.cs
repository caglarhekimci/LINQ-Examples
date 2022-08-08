using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

var fileContent = await File.ReadAllTextAsync("data.json");
var cars = JsonSerializer.Deserialize<CarData[]>(fileContent);

// Print all cars with at least 4 doors
// -------------------------------------------------------------------
//var carsWithAtLeastFourDoors = cars.Where(car => car.NumberOfDoors >= 4);
//foreach (var car in carsWithAtLeastFourDoors)
//{
//    Console.WriteLine($"The car {car.Model} has {car.NumberOfDoors} doors");
//}

// Print all Mazda cars with at least 4 doors
// -------------------------------------------------------------------
//var mazdaWithAtLeastFourDoors = cars.Where(car => car.Make == "Mazda" && car.NumberOfDoors >= 4);
//foreach (var car in mazdaWithAtLeastFourDoors)
//{
//    Console.WriteLine($"The Mazda car {car.Model} has {car.NumberOfDoors} doors");
//}

// Print Make + Model for all Makes that start with "M"
// -------------------------------------------------------------------
// FIRST WAY
cars.Where(car => car.Make.StartsWith("M")) // filtering
    .Select(car => $"{car.Make} {car.Model}") // creating new object
    .ToList() //  add to list
    .ForEach(car => Console.WriteLine(car)); // printing, writing

// SECOND WAY faster and easier than first way
var startingWithM = cars.Where(car => car.Make.StartsWith("M"));
foreach (var car in startingWithM)
{
    Console.WriteLine($"{car.Make} start with M and {car.Model}");
}

// Display a list of the 10 most powerful cars (in terms of hp)
// ------------------------------------------------------------------- *
// THIRD WAY much faster and easier than second way
//cars.OrderByDescending(car => car.HP).Take(10)
//    .ToList()
//    .ForEach(car => Console.WriteLine($"{car.Make}  {car.Model}"));

// Display the number of models per make that appeared after 2008.
// Makes should be displayed with a number of zero if there are no models after 2008.
// -------------------------------------------------------------------
//cars.GroupBy(car => car.Make)
//    .Select(c => new { c.Key, NumberOfModels = c.Count(car => car.Year >= 2008) })
//    .ToList()
//    .ForEach(item => Console.WriteLine($"{item.Key}: {item.NumberOfModels}"));

// Display a list of makes that have at least 2 models with >= 400hp
// -------------------------------------------------------------------
//cars.Where(car => car.HP >= 400).GroupBy(car => car.Make)
//    .Select(car => new { Make = car.Key, NumberOfPowerfulCars = car.Count() })
//    //.Where(make => make.NumberOfPowerfulCars >= 2)
//    .ToList().ForEach(make =>
//    {
//        //Console.WriteLine(make.Make);
//        if (make.NumberOfPowerfulCars >= 2)
//        {
//            Console.WriteLine(make.Make);
//        }
//    });

// Display there average hp per make
//cars.GroupBy(car=>car.Make)
//    .Select(x => new { Make = x.Key, avgHP = x.Average(y=>y.HP) })
//     .ToList().ForEach(z =>
//     {
//         Console.WriteLine($"{z.Make} : {z.avgHP}");
//     });

class CarData
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("car_make")]
    public string Make{ get; set; }
    [JsonPropertyName("car_models")]
    public string Model { get; set; }
    [JsonPropertyName("car_year")]
    public int Year { get; set; }
    [JsonPropertyName("number_of_doors")]
    public int NumberOfDoors { get; set; }
    [JsonPropertyName("hp")]
    public int HP { get; set; }

}

//mockaroo.com