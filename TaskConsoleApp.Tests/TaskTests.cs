using TaskConsoleApp.Task;

namespace TaskConsoleApp.Tests;
public class TaskTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestInitAndGet()
    {
        DateTime now = DateTime.Now;
        MyTask task = new("Example Task", DateOnly.FromDateTime(now));
        Assert.That(task.TaskName, Is.EqualTo("Example Task"));
        Assert.That(task.Date, Is.EqualTo(DateOnly.FromDateTime(now)));
        Assert.That(task.CurrentStatus, Is.EqualTo(MyTaskStatus.Pending));
    }

    [Test]
    public void TestSet()
    {
        DateTime now = DateTime.Now;
        MyTask task = new("Example Task", DateOnly.FromDateTime(now));
        task.TaskName = "Different Name";
        task.CurrentStatus = MyTaskStatus.Completed;
        Assert.That(task.TaskName, Is.EqualTo("Different Name"));
        Assert.That(task.Date, Is.EqualTo(DateOnly.FromDateTime(now)));
        Assert.That(task.CurrentStatus, Is.EqualTo(MyTaskStatus.Completed));

    }
}