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
                    display.Append('\n');
                } else {
                    display.Append("No Task Created Yet\n\n");
                }
                display.Append("Press 'n' to create a new task\n");
                Console.Write(display);
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.N){
                    CreateNewTask(list);
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
    }
}
