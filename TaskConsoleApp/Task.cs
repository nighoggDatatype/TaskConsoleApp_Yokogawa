namespace TaskConsoleApp
{
    public enum TaskStatus
    {
        Pending,
        Completed,
    }
    public class Task
    {
        public string TaskName { get; set; }
        public DateOnly Date { get; set; }
        public TaskStatus CurrentStatus { get; set; }

        public Task(string name, DateOnly date, TaskStatus status = TaskStatus.Pending)
        {
            TaskName = name;
            Date = date;
            CurrentStatus = status;
        }
    }

}
