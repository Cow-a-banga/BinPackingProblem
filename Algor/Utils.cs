using System.Collections.Generic;

namespace BinPackingProblem
{
    public class Utils
    {
        public static IResultData FirstFit(IThing[] things, int containersCapacity)
        {
            var containers = new List<IContainer>();
            var counter = 0;
            for (int i = 0; i < things.Length; i++)
            {
                var needContainer = true;
                foreach (var container in containers)
                {
                    if (container.CanAddThing(things[i], containersCapacity))
                    {
                        container.ThingsId.Add(things[i].id);
                        container.CurrentMass += things[i].Mass;
                        needContainer = false;
                        break;
                    }
                }

                if (!needContainer) continue;
                
                containers.Add(new Container(things[i].id, things[i].Mass));
                counter++;
            }

            return new ResultData
            {
                Containers = containers,
                ContainersNum = counter
            };
        }
    }
}