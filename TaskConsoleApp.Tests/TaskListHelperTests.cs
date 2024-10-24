using TaskConsoleApp.Task;
using TaskConsoleApp.TaskListHelper;

namespace TaskConsoleApp.Tests;
public class TaskListTests
{
    [SetUp]
    public void Setup()
    {
    }

    private List<MyTask> MakeLargeList(int count) {
        DateOnly now = DateOnly.FromDateTime(DateTime.Today);
        List<MyTask> list = new();
        for (int i = 0 ; i < count ; i++) {
            list.Add(new("Task " + i, now));
        }
        return list;
    }
    [Test]
    public void TestPagenation() {
        List<MyTask> emptyList = MakeLargeList(0);
        Assert.IsNull(MyTaskListHelper.GetCurrentPage(emptyList,0));
        List<MyTask> largeList = MakeLargeList(25);
        PageData? firstPage = MyTaskListHelper.GetCurrentPage(largeList,0);
        Assert.That(firstPage, Is.Not.Null);
        Assert.That(firstPage?.page, Has.Count.EqualTo(10));
        Assert.That(firstPage?.page[0].TaskName, Is.EqualTo("Task 0"));
        PageData? lastPage = MyTaskListHelper.GetCurrentPage(largeList,22);
        Assert.That(lastPage, Is.Not.Null);
        Assert.That(lastPage?.page, Has.Count.EqualTo(5));
        Assert.That(lastPage?.page[4].TaskName, Is.EqualTo("Task 24"));

        Assert.That(MyTaskListHelper.GetCurrentPage(largeList,-1), Is.Null);
        Assert.That(MyTaskListHelper.GetCurrentPage(largeList,25), Is.Null);
    }
}