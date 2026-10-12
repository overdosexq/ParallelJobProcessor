using System.Diagnostics;
using ParallelJobProcessor;

Console.CursorVisible = false;
using var tokenSource = new CancellationTokenSource();

var RandomJobsGenerator = new RandomJobsGenerator();

var jobs = RandomJobsGenerator.Generate(5000, 10);
var executionDashboard = new ExecutionDashboard(jobs.Count, 4);
var jobProcessor = new JobProcessor(executionDashboard);

var stopwatch = Stopwatch.StartNew();
var processingTask = jobProcessor.ProcessQueueJobs(jobs, tokenSource.Token);


while (processingTask.IsCompleted == false)
{
    executionDashboard.Render();
    await Task.Delay(100);
}
executionDashboard.Render();
stopwatch.Stop();
var result = await processingTask;

Console.WriteLine();
Console.WriteLine("============================================");
Console.WriteLine("               ОБЩАЯ СТАТИСТИКА");
Console.WriteLine("============================================");
Console.WriteLine($"Всего заданий:       {result.Length}");
Console.WriteLine($"Успешно завершено:   {executionDashboard.SuccessTasksCount}");
Console.WriteLine($"Завершилось ошибкой: {executionDashboard.FailTasksCount}");
Console.WriteLine($"Отменено: {executionDashboard.CanceledTasksCount}");
Console.WriteLine($"Время выполнения:    {stopwatch.ElapsedMilliseconds} мс");
Console.WriteLine("============================================");
Console.ReadLine();