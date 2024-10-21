using TaskConsoleApp.Task;

namespace TaskConsoleApp.TaskList
{
    public class MyTaskList
    {
        const int pageSize = 10;
        public List<MyTask> ListOfTasks;
        public MyTaskList(){ 
            ListOfTasks = new();
        }
        public List<MyTask> GetCurrentPage(int index){
            int pageStart = index/pageSize;
            return ListOfTasks.GetRange(pageStart,pageSize);
        }
        public void DeleteTask(int index){
            ListOfTasks.RemoveAt(index);
        }
        public void AddTask(MyTask task) {
            ListOfTasks.Add(task);
        }
        public MyTask GetTask(int index) {
            return ListOfTasks[index];
        }
    }

}
