namespace BinPackingProblem
{
    public class BruteForceAlgorithm : IPacker
    {
        private IResultData resultData;
        private int ContainersCapacity;

        public IResultData Pack(IInputData inputData)
        {
            resultData = new ResultData
            {
                ContainersNum = int.MaxValue
            };
            ContainersCapacity = inputData.ContainersCapacity;

            GeneratePermutations(inputData.ThingsNum, inputData.Things);

            return resultData;
        }
        
        void GeneratePermutations(int k, IThing[] arr)
        {
            if (k == 1)
            {
                var res = Utils.FirstFit(arr,ContainersCapacity);
                if (res.ContainersNum < resultData.ContainersNum)
                {
                    resultData = res;
                }
            }
            else
            {
                for (int i = 0; i < k; i++)
                {
                    GeneratePermutations(k - 1, arr);
                    if (k % 2 == 0)
                        (arr[i], arr[k - 1]) = (arr[k - 1], arr[i]);
                    else
                        (arr[0], arr[k - 1]) = (arr[k - 1], arr[0]);
                }
            }
        }
        
    }
}