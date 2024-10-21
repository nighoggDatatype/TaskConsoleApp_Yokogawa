namespace TaskConsoleApp.Task
{
    public enum TaskStatus
    {
        Pending,
        Completed,
    }
    public class MyTask
    {
        public string TaskName { get; set; }
        public DateOnly Date { get; set; }
        public TaskStatus CurrentStatus { get; set; }

        public MyTask(string name, DateOnly date, TaskStatus status = TaskStatus.Pending)
        {
            TaskName = name;
            Date = date;
            CurrentStatus = status;
        }
    }

}
