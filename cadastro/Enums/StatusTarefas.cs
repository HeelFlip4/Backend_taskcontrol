using System.ComponentModel;

namespace cadastro.Enums
{
    public enum StatusTarefas
    {
        [Description("A fazer")]
        Afazer =1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concuido")]
        Concluido = 3,

    }
}
