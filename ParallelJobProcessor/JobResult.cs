namespace ParallelJobProcessor;

public class JobResult
{
    public int JobId { get; set; }
    public bool IsSuccessful { get; set; }
    public string? Result  { get; set; }
    public string? ErrorMessage  { get; set; }

    public JobResult(int jobId, bool isSuccessful, string? result, string? errorMessage)
    {
        JobId = jobId;
        IsSuccessful = isSuccessful;
        Result = result;
        ErrorMessage = errorMessage;
    }
}