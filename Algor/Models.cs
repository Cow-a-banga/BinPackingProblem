using System.Collections.Generic;

namespace Algor
{
    public class ResultData:IResultData
    {
        public int ContainersNum { get; set; }
        public List<List<int>> ThingsInContainers { get; set;}
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
    }
    
}