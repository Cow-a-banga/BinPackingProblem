using System;

namespace BinPackingProblem
{
    public class FFSAlgorithm:IPacker
    {
        public IResultData Pack(IInputData inputData)
        {
            Array.Sort(inputData.Things);
            return Utils.FirstFit(inputData.Things,inputData.ContainersCapacity);
        }
    }
}