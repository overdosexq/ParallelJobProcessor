namespace ParallelJobProcessor;

public class RandomJobsGenerator
{
    public List<Job> Generate(int count, int isFailedCount)
    {
        Random random = new();
        List<Job> jobs = new();

        if (isFailedCount > count) throw new ArgumentOutOfRangeException();
        
        for (int i = 0; i < count; i++)
        {
            int durationMs = random.Next(500, 1000);
            bool isFailed = false;
            jobs.Add(new Job(i, $"Задача {i}", durationMs, isFailed));
        }

        int n = jobs.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Job value = jobs[k];
            jobs[k] = jobs[n];
            jobs[n] = value;
        }

        while (isFailedCount > 0)
        {
            jobs[isFailedCount - 1].ShouldFail = true;
            isFailedCount--;
        }
        
        return jobs;
    }
}