// Task is available here: https://adventofcode.com/2022/day/1
using Day01;
Console.WriteLine("Finding the highest calory count of the elves...");

using (var inputFile = new FileStream("input.txt", FileMode.Open))
    using(var streamReader = new StreamReader(inputFile))
{
    var caloryCounter = new CaloryCounter(streamReader);
    try
    {
        int highestInventoryValue = caloryCounter.GetHighestCaloryInventory();
        int caloriesOfHighestThreeInvgentories = caloryCounter.GetCaloryCountOfTopThreeElves();
        Console.WriteLine($"The elve with the most calories carries a total of {highestInventoryValue} calories!");
        Console.WriteLine($"The top three elves carry a total of {caloriesOfHighestThreeInvgentories}");
    }
    catch(Exception ex)
    {
        Console.WriteLine($"An Error occured: {ex}");
    }
}
Console.WriteLine("Press return to exit the program.");
Console.ReadLine();