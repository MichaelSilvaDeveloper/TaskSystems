using System.ComponentModel;

namespace TaskSystems.Enums
{
    public enum TaskStatus
    {
        [Description("Pendente")]
        Pending = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluído")]
        Concluded = 3
    }
}