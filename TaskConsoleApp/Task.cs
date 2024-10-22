namespace TaskConsoleApp.Task
{
    public enum MyTaskStatus
    {
        Pending,
        Completed,
    }
    public class MyTask
    {
        public string TaskName { get; set; }
        public DateOnly Date { get; set; }
        public MyTaskStatus CurrentStatus { get; set; }

        public MyTask(string name, DateOnly date, MyTaskStatus status = MyTaskStatus.Pending)
        {
            TaskName = name;
            Date = date;
            CurrentStatus = status;
        }
    }

}
