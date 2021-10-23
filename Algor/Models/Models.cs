using System.Collections.Generic;

namespace BinPackingProblem
{
    public class ResultData:IResultData
    {
        public int ContainersNum { get; set; }
        public List<IContainer> Containers { get; set;}
    }
    
    public class InputData:IInputData
    {
        public int ThingsNum { get; set; }
        public int ContainersCapacity { get; set;}
        public IThing[] Things { get; set;}
    }
    
    public class Thing:IThing
    {
        public Thing(int id, int mass)
        {
            this.id = id;
            Mass = mass;
        }

        public int id { get; set; }
        public int Mass { get; set; }
        public int CompareTo(object? obj)
        {
            var thing = obj as IThing;
            return thing == null ? 1 : -Mass.CompareTo(thing.Mass);
        }
    }
    
    class Container : IContainer
    {
        
        public Container()
        {
            ThingsId = new List<int>();
            CurrentMass = 0;
        }
        public Container(int thingId, int thingMass)
        {
            ThingsId = new List<int>{thingId};
            CurrentMass = thingMass;
        }

        public List<int> ThingsId { get; set; }
        public int CurrentMass { get; set; }
        public bool CanAddThing(IThing thing, int containerCapacity) => CurrentMass + thing.Mass <= containerCapacity;
    }
    
}