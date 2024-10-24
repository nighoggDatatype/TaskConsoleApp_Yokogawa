using TaskConsoleApp.Task;

namespace TaskConsoleApp.TaskListHelper
{
    public struct PageData{
        public List<MyTask> page;
        public int offset;
        public int pageNum;
        public int pageTotal;
    }
    public class MyTaskListHelper
    {
        public const int pageSize = 10;
        public static PageData? GetCurrentPage(List<MyTask> list, int index){
            if (index < 0 || index >= list.Count) {
                return null;
            }
            int pageNum = index/pageSize;
            int pageStart = pageNum*pageSize;
            PageData data = new();
            data.page = list.GetRange(pageStart,Math.Min(pageSize,list.Count-pageStart));
            data.offset = index % pageSize;
            data.pageNum = pageNum + 1;
            data.pageTotal = (list.Count/pageSize) + 1;
            return data;
        }
    }

}
