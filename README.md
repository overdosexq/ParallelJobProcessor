
# ParallelJobProcessor

**A small educational C#/.NET project for practicing asynchronous programming and concurrent task processing.**

[English](#english) | [Русский](#русский)

---

## English

### About

`ParallelJobProcessor` is a small educational project created to practice asynchronous programming, task coordination, and concurrency in C#/.NET.

The application processes multiple jobs concurrently, limits the number of jobs being processed at the same time, handles failures and cancellation, and displays a live execution dashboard in the console.

This is a learning project, not a production-ready job processing system.

### Features

- Asynchronous job execution with `async` / `await`
- Concurrency limiting with `SemaphoreSlim`
- Error handling and simulated job failures
- Cancellation support with `CancellationToken`
- Thread-safe counters using `Interlocked`
- Synchronization of shared data using `lock`
- A bounded queue of recent execution events
- Live console dashboard with progress and statistics
- Execution time measurement with `Stopwatch`
- Random job generation with configurable failure counts

### Technologies

- C#
- .NET
- `Task` and `Task.WhenAll`
- `async` / `await`
- `SemaphoreSlim`
- `CancellationToken`
- `Interlocked` and `lock`
- Generic collections

> **Note:** This project focuses on asynchronous programming and concurrency, not manual thread management. It does not explicitly create threads with `new Thread()`. The .NET runtime manages the underlying execution, and `async` / `await` does not guarantee a separate thread for every task.

### Getting Started

**Prerequisites**

- A compatible .NET SDK
- Git (optional, for cloning the repository)

**Clone the repository**

```bash
git clone https://github.com/overdosexq/ParallelJobProcessor.git
cd ParallelJobProcessor
```

**Run the application**

```bash
dotnet run
```

If the solution contains multiple projects, run the command from the directory containing the intended startup project, or specify the project file explicitly.

### Project Status

Completed educational mini-project. Created for personal practice and experimentation with C#/.NET concurrency and asynchronous programming.

---

## Русский

### О проекте

`ParallelJobProcessor` — небольшой учебный проект на C#/.NET, созданный для практики асинхронного программирования, координации задач и работы с конкурентным выполнением.

Приложение обрабатывает несколько заданий одновременно, ограничивает количество задач, выполняющихся в один момент времени, обрабатывает ошибки и отмену операций, а также отображает ход выполнения в консольном дашборде.

Это учебный проект, а не готовая к промышленному использованию система обработки заданий.

### Возможности

- Асинхронное выполнение заданий с помощью `async` / `await`
- Ограничение параллелизма с помощью `SemaphoreSlim`
- Обработка ошибок и имитация неудачного выполнения заданий
- Поддержка отмены операций через `CancellationToken`
- Потокобезопасное изменение счётчиков с помощью `Interlocked`
- Синхронизация доступа к общим данным с помощью `lock`
- Очередь последних событий с ограниченным размером
- Консольный дашборд с отображением прогресса и статистики
- Измерение времени выполнения с помощью `Stopwatch`
- Генерация случайных заданий с заданным количеством ошибок

### 🛠️ Используемые технологии

- C#
- .NET
- `Task` и `Task.WhenAll`
- `async` / `await`
- `SemaphoreSlim`
- `CancellationToken`
- `Interlocked` и `lock`
- Обобщённые коллекции

> **Примечание:** проект посвящён асинхронности и конкурентному выполнению задач, а не ручному управлению потоками. В нём нет явного создания потоков через `new Thread()`. Управление фактическим выполнением осуществляется средой .NET, а `async` / `await` не гарантируют выделение отдельного потока для каждой задачи.

### Запуск проекта

**Требования**

- Совместимый .NET SDK
- Git (необязательно, если репозиторий уже скачан)

**Клонирование репозитория**

```bash
git clone https://github.com/overdosexq/ParallelJobProcessor.git
cd ParallelJobProcessor
```

**Запуск приложения**

```bash
dotnet run
```

Если решение содержит несколько проектов, запускай команду из папки нужного стартового проекта либо явно укажи файл проекта.

### 📌татус проекта

Завершённый учебный мини-проект. Создан для самостоятельной практики и экспериментов с конкурентным выполнением задач и асинхронным программированием в C#/.NET.
