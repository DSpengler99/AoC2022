using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01
{
    internal class CaloryCounter
    {
        private StreamReader caloryFileContent;

        public CaloryCounter(StreamReader caloryFileContent)
        {
            this.caloryFileContent = caloryFileContent;
        }

        public int GetHighestCaloryInventory()
        {
            try
            {
                List < List<int>> inventories = getElveInventories();
                List<int> caloryValues = calculateTotalCaloriesForInventories(inventories);
                caloryValues = caloryValues.OrderDescending().ToList();
                return caloryValues[0];
            }
            catch
            {
                throw;
            }
        }

        public int GetCaloryCountOfTopThreeElves()
        {
            try
            {
                List<List<int>> inventories = getElveInventories();
                List<int> caloryValues = calculateTotalCaloriesForInventories(inventories);
                caloryValues = caloryValues.OrderDescending().ToList();
                return caloryValues[0] + caloryValues[1] + caloryValues[2];
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private List<List<int>> getElveInventories()
        {
            string line;
            var inventories = new List<List<int>>();
            var singleInventory = new List<int>();
            caloryFileContent.BaseStream.Position = 0;
            caloryFileContent.DiscardBufferedData();
            while((line = caloryFileContent.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    inventories.Add(singleInventory);
                    singleInventory = new List<int>();
                }
                else if(int.TryParse(line, out int number))
                {
                    singleInventory.Add(number);
                }
                else
                {
                    throw new InvalidDataException($"The provided file contains atleast one line which is not empty or a number. Fault line contains text: {line}");
                }
            }
            return inventories;
        }

        private List<int> calculateTotalCaloriesForInventories(List<List<int>> inventories)
        {
            var caloryValues = new List<int>();
            inventories.ForEach(inv =>
            {
                int inventoryValue = 0;
                inv.ForEach(calories => inventoryValue += calories);
                caloryValues.Add(inventoryValue);
            });
            return caloryValues;
        }

    }
}
