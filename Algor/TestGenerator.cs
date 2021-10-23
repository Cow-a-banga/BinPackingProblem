using System;

namespace BinPackingProblem
{
    public class TestGenerator
    {
        public InputData Generate(int thingsCount, int containersCapacity)
        {
            var result = new InputData
            {
                ThingsNum = thingsCount,
                ContainersCapacity = containersCapacity,
                Things = new IThing[thingsCount]
            };
            
            Random random = new Random();

            for (int i = 0; i < thingsCount; i++)
            {
                int mass = random.Next(1, containersCapacity/2);
                result.Things[i] = new Thing(i + 1, mass);
            }

            return result;
        }
    }
}