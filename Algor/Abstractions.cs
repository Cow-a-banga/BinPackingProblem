using System.Collections.Generic;

namespace Algor
{
    public interface IResultData
    {
    int ContainersNum { get; }
    List<List<int>> ThingsInContainers {get;}
    }

    public interface IInputData
    {
    int ThingsNum { get; }
    int ContainersCapacity { get; }
    IThing[] Things { get; }
    }
    
    public interface IThing
    {
    public int id { get; set; }
    public int Mass { get; set;}
    }
    interface IPacker
    {
    IResultData Pack(IInputData inputData);
    }
}