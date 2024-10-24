using System.Globalization;
using System.Text;
using TaskConsoleApp.Task;
using TaskConsoleApp.TaskListHelper;

namespace TaskConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<MyTask> list = [];
            int selectedTask = 0;
            bool loop = true;
            while(loop) {
                Console.Clear();
                StringBuilder display = new();
                var page = MyTaskListHelper.GetCurrentPage(list,selectedTask);
                if (page.HasValue){
                    var pageData = page.Value;
                    for(int i = 0; i < pageData.page.Count; i++){
                        display.Append(i == pageData.offset ? "> " : "  ");
                        display.Append(pageData.page[i].TaskName);
                        display.Append(" - Due: " + pageData.page[i].Date);
                        display.Append(" - " + pageData.page[i].CurrentStatus.ToString());
                        display.Append('\n');
                    }
                    display.Append($"Page {pageData.pageNum} of {pageData.pageTotal}\n\n");
                } else {
                    display.Append("No Task Created Yet\n\n");
                }
                display.Append("Press 'n' to create a new task\n");
                if(page.HasValue){
                    display.Append("Press 't' to toggle the status of the selected task\n");
                    display.Append("Press 'd' to delete the selected task\n");
                    display.Append("Use the arrow keys to navigate through the task list\n");
                }
                Console.Write(display);
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.N) {CreateNewTask(list);}
                if(page.HasValue) {
                    switch(key.Key) {
                        case ConsoleKey.T:
                            if (list[selectedTask].CurrentStatus == MyTaskStatus.Pending){
                                list[selectedTask].CurrentStatus = MyTaskStatus.Completed;
                            } else {
                                list[selectedTask].CurrentStatus = MyTaskStatus.Pending;
                            }
                            break;
                        case ConsoleKey.D:
                            list.RemoveAt(selectedTask);
                            break;
                        case ConsoleKey.UpArrow:
                            selectedTask -= 1;
                            break;
                        case ConsoleKey.DownArrow:
                            selectedTask += 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            selectedTask -= MyTaskListHelper.pageSize;
                            break;
                        case ConsoleKey.RightArrow:
                            selectedTask += MyTaskListHelper.pageSize;
                            break;
                    }
                    if (selectedTask >= list.Count){
                        selectedTask = list.Count - 1;
                    }
                    if (selectedTask < 0) {
                        selectedTask = 0;
                    }
                }
                
            }
        }
        static void CreateNewTask(List<MyTask> list){
            string? title = null;
            while(title == null || title.Trim() == ""){
                Console.Clear();
                Console.Write("New Task Title: ");
                title = Console.ReadLine();
            }
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dateTimeOut;
            bool success;
            do
            {
                Console.Clear();
                Console.WriteLine("New Task Title: " + title);
                Console.Write("Due Date (DD/MM/YYYY): ");
                var dateString = Console.ReadLine();
                success = DateTime.TryParseExact(dateString, format, provider, DateTimeStyles.None, out dateTimeOut);
            } while (!success);
            list.Add(new(title, DateOnly.FromDateTime(dateTimeOut)));
        }
        private static List<MyTask> MakeLargeList(int count) { //Debug only
            DateOnly now = DateOnly.FromDateTime(DateTime.Today);
            List<MyTask> list = new();
            for (int i = 0 ; i < count ; i++) {
                list.Add(new("Task " + i, now));
            }
            return list;
        }
    }
}
