namespace ParallelJobProcessor;

public class Job
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DurationMs { get; set; }
    public bool ShouldFail { get; set; }

    public Job(int id, string name, int durationMs, bool shouldFail = false)
    {
        Id = id;
        Name = name;
        DurationMs = durationMs;
        ShouldFail = shouldFail;
    }
}