namespace Biblioteca
{
    public class Funcionario : Pessoa
    {
        private static int ultimoId = 0;
        private int id_funcionario;
        private string funcao_funcionario;
        private decimal salario_funcionario;

        public Funcionario()
        {
            id_funcionario = ++ultimoId;
        }
        public int Id_Funcionario {
            get => id_funcionario;
            set => throw new ArgumentException("o id não pode ser alterado!");
        }
        public string Funcao_Funcionario {
            get => funcao_funcionario;
            set => funcao_funcionario = (string.IsNullOrWhiteSpace(value)) 
            ? throw new ArgumentException("a função é obrigatória!") : value;
        }
        public decimal Salario_Funcionario {
            get => salario_funcionario;
            set => salario_funcionario = (value <= 0)
            ? throw new ArgumentException("o salário é obrigatório!") : value;
        }
    }
}