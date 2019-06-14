using NBench;
using ProjectManagerApi.Controllers;

namespace ProjectManagerApi.Test
{
    class ProjectManagerNBench
    {
        private const string AddCounterName = "AddCounter";
        private Counter addCounter;
        private int key;

        private const int AcceptableMinAddThroughput = 100;

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            addCounter = context.GetCounter(AddCounterName);
            key = 0;
        }
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 60000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(AddCounterName)]
        [CounterThroughputAssertion(AddCounterName, MustBe.GreaterThan, AcceptableMinAddThroughput)]
        public void GetAllUsersCounterThroughputBenchMark(BenchmarkContext context)
        {
            UserController userController = new UserController();
            userController.Get();
            addCounter.Increment();
        }
    }
}
