namespace TeamWork.Models
{
    //набор констант
    public enum TaskPriority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    public enum TaskStatus
    {
        New = 1,
        InProgress = 2,
        Done = 3
    }

    //шаблон объекта Задача
    public class Task
    {
        //свойства:
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Executor { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset Deadline { get; set; }

        public TaskStatus Status { get; set; }

        //конструктор для начальных значений, если они не были определены кем-то
        public Task()
        {
            CreatedAt = DateTimeOffset.UtcNow;
            Status = TaskStatus.New;
            Priority = TaskPriority.Low;
        }

        //методы:
        public void AssignExecutor(string executor) //назначение исполнителя
        {
            Executor = executor;
        }

        public void UpdatePriority(TaskPriority newPriority) //обновление приоритета
        {
            Priority = newPriority;
        }

        public bool IsOverdue() //проверка просроченности задачи
        {
            return Deadline < DateTime.Now;
        }
        
        public void UpdateStatus(TaskStatus newStatus)  //обновление статуса
        {
            Status = newStatus;
        }
    }
}
