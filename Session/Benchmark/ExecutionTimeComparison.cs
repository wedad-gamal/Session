using BenchmarkDotNet.Attributes;

namespace Session.Benchmark
{
    public class ExecutionTimeComparison
    {

        [Benchmark]
        public void Sleep1000()
        {
            Thread.Sleep(1000);
        }

        [Benchmark]
        public void Sleep4000()
        {
            Thread.Sleep(4000);
        }
    }
}
