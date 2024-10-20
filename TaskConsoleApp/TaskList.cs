namespace TaskConsoleApp
{
    public class TaskList
    {
        const int pageSize = 10;
        public List<Task> ListOfTasks;
        public TaskList(){ 
            ListOfTasks = new();
        }
        public List<Task> GetCurrentPage(int index){
            int pageStart = index/pageSize;
            return ListOfTasks.GetRange(pageStart,pageSize);
        }
        public void DeleteTask(int index){
            ListOfTasks.RemoveAt(index);
        }
        public void AddTask(Task task) {
            ListOfTasks.Add(task);
        }
        public Task GetTask(int index) {
            return ListOfTasks[index];
        }
    }

}
