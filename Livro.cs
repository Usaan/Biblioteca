namespace Biblioteca
{
    public class Livro
    {
        private string isbn;
        private string titulo;
        private string autor;
        private string edicao;
        private string genero;

        public string ISBN {
            get => isbn;
            set => isbn = (string.IsNullOrWhiteSpace(value))
            ? throw new ArgumentException("O ISBN do livro é obrigatório.") : value;
        }
        public string Titulo
        { 
            get => titulo; 
            set => titulo = (string.IsNullOrWhiteSpace(value))
            ? throw new ArgumentException("O titulo do livro é obrigatório.") : value; 
        }
        
        public string Autor {
        get => autor;
        set => autor = (string.IsNullOrWhiteSpace(value))
        ? throw new ArgumentException("O nome do autor é obrigatório.") : value;}

        public string Edicao {
        get => edicao;
        set => edicao = (string.IsNullOrWhiteSpace(value))
        ? throw new ArgumentException("A edição do livro é obrigatória.") : value;}

        public string Genero {
        get => genero;
        set => genero = (string.IsNullOrWhiteSpace(value))
        ? throw new ArgumentException("O gênero do livro é obrigatório") : value;}

        static string Input(string Texto, string Value)
        {
            Console.WriteLine($"{Texto} (Atual: {Value})");
            string input = Console.ReadLine();
            return string.IsNullOrWhiteSpace(input) ? Value : input;
        }
        
        public void Cadastrar_Livro()
        {
            bool isbnValido = false, tituloValido = false, autorValido = false, edicaoValida = false, generoValido = false;

            while (!isbnValido)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite o ISBN: ");
                    ISBN = Console.ReadLine();
                    Console.Clear();
                    isbnValido = true;
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Erro: {error.Message}");
                    Console.ReadKey();
                }
            }
            while (!tituloValido)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite o nome do Livro: ");
                    Titulo = Console.ReadLine();
                    Console.Clear();
                    tituloValido = true;
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"Erro: {error.Message}");
                    Console.ReadKey();
                }
            }
            while (!autorValido)
            {
                try 
                {
                    Console.Clear();
                    Console.WriteLine("Digite o autor do Livro: ");
                    Autor = Console.ReadLine();
                    Console.Clear();
                    autorValido = true;
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"Erro: {error.Message}");
                    Console.ReadKey();
                }
            }

            while (!edicaoValida)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite a edição do Livro: ");
                    Edicao = Console.ReadLine();
                    Console.Clear();
                    edicaoValida = true;
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"Erro: {error.Message}");
                    Console.ReadKey();
                }
            }

            while (!generoValido)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Digite o gênero do Livro: ");
                    Genero = Console.ReadLine();
                    Console.Clear();
                    generoValido = true;
                }
                catch (ArgumentException error)
                {
                    Console.WriteLine($"Erro: {error.Message}");
                    Console.ReadKey();
                }
            }
        }

        public void Editar_Livro(List<Livro> livros)
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("Digite o ISBN do livro que deseja editar: ");
            string ISBN = Console.ReadLine();
            Console.Clear();

            Livro livro = livros.FirstOrDefault(l => l.ISBN == ISBN);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                Console.ReadKey();
                return;
            }
            
            livro.Titulo = Input("Digite o título: ", livro.Titulo);
            Console.Clear();
            livro.Autor = Input("Digite o autor: ", livro.Autor);
            Console.Clear();
            livro.Edicao = Input("Digite a edição: ", livro.Edicao);
            Console.Clear();
            livro.Genero = Input("Digite o gênero: ", livro.Genero);

            Console.Clear();
            Console.WriteLine("Livro editado com sucesso!");
        }
    
        public void Excluir_Livro(List<Livro> livros)
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("Digite o ISBN do livro que deseja excluir: ");
            string ISBN = Console.ReadLine();
            Console.Clear();
            Livro livro = livros.FirstOrDefault(l => l.ISBN == ISBN);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                Console.ReadKey();
                return;
            }
            livros.Remove(livro);
            Console.WriteLine("Livro excluído com sucesso!");
        }
    }
}	