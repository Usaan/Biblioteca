abstract class Pessoa
{
    private string nome;
    private string cpf;
    private string endereco;

    public string Nome
    {
        get => nome;
        set => nome = (string.IsNullOrWhiteSpace(value)) 
        ? throw new ArgumentException("o nome é obrigatório!"): value;
    }
    public string Cpf
    {
        get => cpf;
        set => cpf = (!validarCpf(value)) 
        ? throw new ArgumentException("cpf inválido!") : value;
    }
    public string Endereco
    {
        get => endereco;
        set => endereco = (string.IsNullOrWhiteSpace(value)) 
        ? throw new ArgumentException("o endereço é obrigatório!"): value;
    }

    public void cadastrarPessoa()
    {
        bool nomeValido = false, cpfValido = false, enderecoValido = false;

        while (!nomeValido)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o nome: ");
                Nome = Console.ReadLine();
                Console.Clear();
                nomeValido = true;
            }
            catch (ArgumentException error)
            {
                Console.WriteLine($"Erro: {error.Message} Tente novamente.");
                Console.ReadKey();
            }
        }

        while (!cpfValido)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o CPF: ");
                Cpf = Console.ReadLine();
                Console.Clear();
                cpfValido = validarCpf(Cpf);
            }
            catch (ArgumentException error)
            {
                Console.WriteLine($"Erro: {error.Message} Tente novamente.");
                Console.ReadKey();
            }
        }

        while (!enderecoValido)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o endereço: ");
                Endereco = Console.ReadLine();
                Console.Clear();
                enderecoValido = true;
            }
            catch (ArgumentException error)
            {
                Console.WriteLine($"Erro: {error.Message} Tente novamente.");
                Console.ReadKey();
            }
        }
    }
    public void exibirPessoa()
    {
        Console.WriteLine($"Nome: {Nome}\nCPF: {Cpf}\nENDEREÇO: {Endereco}");
    }

    private bool validarCpf(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) {
            throw new ArgumentException("O cpf da pessoa é obrigatório!");
        }
        string cpfPostInput = value.Replace(".", "").Replace("-", "");
        if (cpfPostInput.Length != 11) {
            throw new ArgumentException("Cpf digitado de forma equivocada!");
        }

        int veri1 = 0, veri2 = 0, digitoVeri, soma = 0;
        var cpfInt = cpfPostInput.Select(caractere => int.Parse(caractere.ToString())).ToArray();

        for (int i = 0; i < 11; i++) {
            soma += cpfInt[i];
        } 
        if (soma / 11 == cpfInt[0]) {
            return false;
        }
        for (int j = 0; j < 9; j++) {
            veri1 += cpfInt[j] * (10 - j);
            veri2 += cpfInt[j] * (11 - j);
        }

        veri1 %= 11;
        veri1 = (veri1 < 2 || veri1 > 9) ? 0 : (11 - veri1);

        veri2 = (veri2 + cpfInt[9] * 2) % 11;
        veri2 = (veri2 < 2 || veri2 > 9) ? 0 : (11 - veri2);

        digitoVeri = (veri1 * 10) + veri2;
        return (cpfInt[9] * 10 + cpfInt[10] == digitoVeri);
    }
}