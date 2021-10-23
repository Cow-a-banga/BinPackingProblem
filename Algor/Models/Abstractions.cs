using System;
using System.Collections.Generic;

namespace BinPackingProblem
{
    public interface IResultData
    {
        int ContainersNum { get; }
        List<IContainer> Containers { get;}
    }

    public interface IInputData
    {
        int ThingsNum { get; }
        int ContainersCapacity { get; }
        IThing[] Things { get; }
    }
    
    public interface IThing:IComparable
    {
        int id { get; }
        int Mass { get;}
    }

    public interface IContainer
    {
        List<int> ThingsId { get; }
        int CurrentMass { get; set; }
        bool CanAddThing(IThing thing, int containerCapacity);
    }
    interface IPacker
    {
        IResultData Pack(IInputData inputData);
    }
}