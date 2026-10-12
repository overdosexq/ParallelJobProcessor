namespace ParallelJobProcessor;

public class JobProcessor
{
    private SemaphoreSlim SemaphoreSlim = new(3);
    private ExecutionDashboard _executionDashboard;

    public JobProcessor(ExecutionDashboard executionDashboard)
    {
        _executionDashboard = executionDashboard;
    }

    public async Task<JobResult> Process(Job job, CancellationToken token)
    {
        bool semaphoreAcquired = false;

        try
        {
            await SemaphoreSlim.WaitAsync(token);
            semaphoreAcquired = true;

            _executionDashboard.AddRunningTask();

            _executionDashboard.AddMessage(
                $"[START]   Задание #{job.Id}: {job.Name}");

            await Task.Delay(job.DurationMs, token);

            if (job.ShouldFail)
            {
                throw new InvalidOperationException(
                    $"Ошибка при обработке задания #{job.Id}");
            }

            _executionDashboard.AddMessage(
                $"[SUCCESS] Задание #{job.Id}: {job.Name}");

            _executionDashboard.AddSuccessTask();

            return new JobResult(
                job.Id,
                true,
                $"{job.Name} завершено",
                null);
        }
        catch (InvalidOperationException)
        {
            _executionDashboard.AddMessage(
                $"[FAIL]    Задание #{job.Id}: {job.Name}");

            _executionDashboard.AddFailTask();

            return new JobResult(
                job.Id,
                false,
                null,
                $"Ошибка при обработке задания #{job.Id}");
        }
        catch (OperationCanceledException)
        {
            _executionDashboard.AddMessage(
                $"[CANCELED] Задание #{job.Id}: {job.Name}");

            _executionDashboard.AddCanceledTask();

            return new JobResult(
                job.Id,
                false,
                null,
                $"Операция отменена: {job.Name}");
        }
        finally
        {
            if (semaphoreAcquired)
            {
                _executionDashboard.RemoveRunningTask();
                SemaphoreSlim.Release();
            }
        }
    }

    public async Task<JobResult[]> ProcessQueueJobs(
        IEnumerable<Job> jobs,
        CancellationToken token)
    {
        var jobsInTasks = jobs.Select(job => Process(job, token));

        return await Task.WhenAll(jobsInTasks);
    }
}