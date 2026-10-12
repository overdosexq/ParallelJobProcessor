namespace ParallelJobProcessor;

public class ExecutionDashboard
{
    private readonly object _messageLock = new();
    
    private readonly int _tasksCount;
    private int _successTasksCount;
    private int _failTasksCount;
    private int _canceledTasksCount;
    private int _runningTasksCount;
    
    public int TasksCount => _tasksCount;
    public int SuccessTasksCount => _successTasksCount;
    public int FailTasksCount => _failTasksCount;
    public int CanceledTasksCount => _canceledTasksCount;
    public int RunningTasksCount => _runningTasksCount;
    
    private readonly Queue<string> _messages  = new();
    private readonly int _maxMessagesSize = 4;

    public ExecutionDashboard(int tasksCount, int maxMessagesSize)
    {
        _tasksCount = tasksCount;
        _maxMessagesSize = maxMessagesSize;
    }

    public void AddSuccessTask()
    {
         Interlocked.Increment(ref _successTasksCount);
    }    
    public void AddFailTask()
    {
        Interlocked.Increment(ref _failTasksCount);
    }    
    public void AddCanceledTask()
    {
        Interlocked.Increment(ref _canceledTasksCount);
    }    
    public void AddMessage(string message)
    {
        lock (_messageLock)
        {
            _messages.Enqueue(message);
            while (_messages.Count > _maxMessagesSize)
            {
                _messages.Dequeue();
            }
        }
        
    }
    public string[] GetMessages()
    {
        lock (_messageLock)
        {
            return _messages.ToArray();
        }
    }

    public void AddRunningTask()
    {
        Interlocked.Increment(ref _runningTasksCount);
    }    
    public void RemoveRunningTask()
    {
        Interlocked.Decrement(ref _runningTasksCount);
    }

    public void Render()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("==============================");
        Console.WriteLine("      ВЫПОЛНЕНИЕ ЗАДАНИЙ      ");
        Console.WriteLine("==============================");
        Console.WriteLine($"Всего заданий: {TasksCount}");
        Console.WriteLine($"Выполняется: {_runningTasksCount} / 3");
        Console.WriteLine($"Успешно завершено: {SuccessTasksCount}");
        Console.WriteLine($"Завершилось ошибкой: {FailTasksCount}");
        Console.WriteLine($"Прогресс: {SuccessTasksCount + FailTasksCount + CanceledTasksCount} / {TasksCount}");
        Console.WriteLine("------------------------------");
        Console.WriteLine("Последние события");
        foreach (var message in GetMessages())
        {
            Console.WriteLine(message);
        }
        Console.WriteLine("------------------------------");
    }
}