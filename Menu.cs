namespace Biblioteca
{
    public class Menu
    {
        public void MenuPrincipal()
        {
            bool menu = true;
            string dirLivro = Path.Combine(Directory.GetCurrentDirectory(), "livros.txt");
            dirExiste(dirLivro);
            List<Livro> livros = loadBooks(dirLivro);

            while (menu)
            {
                Console.Clear();
                Console.WriteLine("                      MENU PRINCIPAL");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("[1] Cadastrar Livro.\t\t[2] Listar Livros.");
                Console.WriteLine("[3] Cadastrar Funcionário.\t[4] Listar Funcionários.");
                Console.WriteLine("[5] Cadastrar Aluno.\t\t[6] Listar Alunos.");
                Console.WriteLine("[0] Sair.");
                Console.WriteLine("----------------------------------------------------------");
                Console.Write("Escolha a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Clear();

                        Livro livro = new();
                        livro.cadastrar_livro();
                        livros.Add(livro);
                        Console.Clear();
                        writeBook(dirLivro, livros);
                        break;

                    case 2:
                        Console.Clear();
                        livros = loadBooks(dirLivro);
                        showBooks(livros);
                        Console.ReadKey();
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        break;

                    case 0:
                        menu = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void dirExiste(string dirArquivo)
        {
            if (!File.Exists(dirArquivo))
            {
                File.Create(dirArquivo).Close();
            }
        }

        static void showBooks(List<Livro> livros)
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            foreach (Livro livro in livros)
            {
                Console.WriteLine($"Título: {livro.Titulo}\nAutor: {livro.Autor}\nEdição: {livro.Edicao}\nGênero: {livro.Genero}");
                Console.WriteLine("----------------------------------------------------");
            }
        }

        public List<Livro> loadBooks(string dirLivro)
        {
            List<Livro> livros = new();
            if (File.Exists(dirLivro))
            {
                string[] linhas = File.ReadAllLines(dirLivro);
                Livro livro = null;

                foreach (string linha in linhas)
                {
                    if (linha.StartsWith("Título:"))
                    {
                        livro = new Livro();
                        livro.Titulo = linha.Replace("Título: ", "").Trim();
                    }
                    else if (linha.StartsWith("Autor:") && livro != null)
                    {
                        livro.Autor = linha.Replace("Autor: ", "").Trim();
                    }
                    else if (linha.StartsWith("Edição:") && livro != null)
                    {
                        livro.Edicao = linha.Replace("Edição: ", "").Trim();
                    }
                    else if (linha.StartsWith("Gênero:") && livro != null)
                    {
                        livro.Genero = linha.Replace("Gênero: ", "").Trim();
                        livros.Add(livro);
                    }
                }
            }

            return livros;
        }

        public void writeBook(string dirLivro, List<Livro> livros)
        {
            using var writer = new StreamWriter(dirLivro, append: false);
            {
                foreach (Livro livro in livros)
                {
                    writer.WriteLine($"Título: {livro.Titulo}");
                    writer.WriteLine($"Autor: {livro.Autor}");
                    writer.WriteLine($"Edição: {livro.Edicao}");
                    writer.WriteLine($"Gênero: {livro.Genero}");
                    writer.WriteLine("---------------------------------------------------------------");
                }
            }
        }
    }
}
