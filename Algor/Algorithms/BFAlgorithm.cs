using System.Collections.Generic;

namespace BinPackingProblem
{
    public class BFAlgorithm:IPacker
    {
        public IResultData Pack(IInputData inputData)
        {
            var containers = new List<IContainer>();
            foreach (var thing in inputData.Things)
            {
                IContainer selectedCont = null;
                foreach (var cont in containers)
                {
                    if (cont.CanAddThing(thing, inputData.ContainersCapacity) && (selectedCont == null || selectedCont.CurrentMass < cont.CurrentMass))
                        selectedCont = cont;
                }
                /* найден контейнер с наименьшим свободным объёмом после упаковки */
                if (selectedCont != null)
                {
                    selectedCont.ThingsId.Add(thing.id);
                    selectedCont.CurrentMass += thing.Mass;
                }
                /* взять новый контейнер */
                else
                    containers.Add(new Container(thing.id, thing.Mass));
            }

            return new ResultData
            {
                Containers = containers,
                ContainersNum = containers.Count
            };
        }
    }
}