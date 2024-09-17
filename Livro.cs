namespace Biblioteca
{
    public class Livro
    {
        private string titulo;
        private string autor;
        private string edicao;
        private string genero;

        public string Titulo { 
        get => titulo; 
        set => titulo = (string.IsNullOrWhiteSpace(value))
        ? throw new ArgumentException("O titulo do livro é obrigatório.") : value; }
        
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

        public void cadastrar_livro()
        {
            bool tituloValido = false, autorValido = false, edicaoValida = false, generoValido = false;

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

        public void retornar_livro()
        {
            Console.WriteLine($"Nome: {Titulo}\nAutor: {Autor}\nEdição: {Edicao}\nGenero: {Genero}");
        }
    }
}	