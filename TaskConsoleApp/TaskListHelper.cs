using TaskConsoleApp.Task;

namespace TaskConsoleApp.TaskListHelper
{
    public class MyTaskListHelper
    {
        const int pageSize = 10;
        public static List<MyTask>? GetCurrentPage(List<MyTask> list, int index){
            if (index < 0 || index >= list.Count) {
                return null;
            }
            int pageStart = index/pageSize;
            return list.GetRange(pageStart,pageSize);
        }
    }

}
