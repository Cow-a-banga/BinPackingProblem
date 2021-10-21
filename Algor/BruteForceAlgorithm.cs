using System.Collections.Generic;
using System.Linq;

namespace Algor
{
    class Container
    {
        public List<int> Things { get; set; }
        public int CurrentMass { get; set; }
    }
    
    public class BruteForceAlgorithm:IPacker
    {
        private List<Container> Containers = new List<Container>();
        private int Count = int.MaxValue;
        private int ContainersCapacity;
        
        public IResultData Pack(IInputData inputData)
        {
            ContainersCapacity = inputData.ContainersCapacity;
            GeneratePermutations(inputData.ThingsNum, inputData.Things);
            return new ResultData
            {
                ContainersNum = Count,
                ThingsInContainers = Containers.Select(c => c.Things).ToList()
            };
        }
        
        void GeneratePermutations(int k, IThing[] arr)
        {
            if (k == 1)
            {
                var res = FF(arr);
                if (res.Count < Count)
                {
                    Count = res.Count;
                    Containers = res;
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    GeneratePermutations(k-1,arr);
                    if (k % 2 == 0)
                        (arr[i], arr[k - 1]) = (arr[k - 1], arr[i]);
                    else
                        (arr[0], arr[k - 1]) = (arr[k - 1], arr[0]);
                }
            }
        }

        private List<Container> FF(IThing[] things)
        {
            List<Container> containers = new List<Container>();
            for (int i = 0; i < things.Length; i++)
            {
                bool needContainer = true;
                for (int j = 0; j < containers.Count; j++)
                {
                    if (containers[j].CurrentMass + things[i].Mass <= ContainersCapacity)
                    {
                        containers[j].Things.Add(things[i].id);
                        containers[j].CurrentMass += things[i].Mass;
;                       needContainer = false;
                        break;
                    }
                }

                if (needContainer)
                {
                    containers.Add(new Container{Things = new List<int>{things[i].id}, CurrentMass = things[i].Mass});
                }
            }

            return containers;
        }
    }
}