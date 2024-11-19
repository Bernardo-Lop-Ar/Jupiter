using System.Collections.Generic;
using System.Threading;
using System;
using System.Data;

public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();

    public static void Main()
    {
        string senha = "";
        bool produtos = false;

        while (true)
        {

            Console.WriteLine("--------------------------BEM-VINDO AO--------------------------");
            Console.WriteLine("");
            Console.WriteLine(Logo());

            if (senha == "")
            {
                Console.WriteLine("INFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("----------------------ADICIONANDO OS PRODUTOS----------------------");
                Console.WriteLine(".");
                Thread.Sleep(1000);
                Console.WriteLine("..");
                Thread.Sleep(1000);
                Console.WriteLine("...");
                Thread.Sleep(1000);
                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("PRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar......");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar....");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar...");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar..");
                Thread.Sleep(1000);
                Console.WriteLine("Vamos começar.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("-----------PAINEL DE CONTROLE-----------");
                Console.WriteLine("");
                Console.WriteLine("[1] - Vender Produto");
                Console.WriteLine("[2] - Listar de produtos");
                Console.WriteLine("[3] - Alterar Senha");
                Console.WriteLine("[4] - Fechar Caixa");

                int decisao = Convert.ToInt32(Console.ReadLine());

                switch (decisao)
                {
                    case 1:
                        VenderProdutos();
                        break;

                    case 2:
                        ListarProdutos();
                        break;


                    case 3:
                        senha = AlterarSenha(senha);
                        break;

                    case 4:
                        FecharCaixa();
                        break;

                    default:
                        Console.WriteLine("Opção Invalida, tente novamente...");
                        Console.ReadKey();
                        break;

                }
            }

        }
    }

    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR\n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR\n";
        logo += "\n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";
        logo += "          33    33  00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          3333333   00    00  00    00 00    00  !!!\n";
        logo += "                33  00    00  00    00 00    00  !!!\n";
        logo += "          33    33  00    00  00    00 00    00     \n";
        logo += "          3333333   00000000  00000000 00000000  !!!\n";

        return logo;
    }
    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }

    static void VenderProdutos()
    {
        Console.Clear();
        Console.WriteLine("Informe o ID do produto para vender:");
        int idProduto = Convert.ToInt32(Console.ReadLine());
        Produto produto = listaProdutos.Find(p => p.Id == idProduto);

        if (produto != null)
        {
            Console.WriteLine($"Produto: {produto.Nome}");
            Console.WriteLine($"Quantidade Disponível: {produto.Quantidade}");

            Console.WriteLine("Digite a quantidade a ser vendida: ");
            int quantidadeVendida = Convert.ToInt32(Console.ReadLine());

            if (quantidadeVendida <= produto.Quantidade)
            {
                produto.Quantidade -= quantidadeVendida;
                Console.WriteLine($"Venda realizada com sucesso! Restante em estoque: {produto.Quantidade}");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente em estoque");
            }
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
        Console.ReadKey();
    }

    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("Lista de Produtos:");

        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
        }

        Console.ReadKey();
    }


    static string AlterarSenha(string senhaAtual)
    {
        Console.Clear();
        Console.WriteLine("Informe a Antiga senha");
        string old = Console.ReadLine();

        if (old != senhaAtual)
        {
            Console.WriteLine("Senha antiga incorreta");
        }
        else
        {
            Console.WriteLine("Informe a nova senha");
            string new1 = Console.ReadLine();

            Console.WriteLine("Informe a nova senha outra vez");
            string new2 = Console.ReadLine();

            if (new1 != new2)
            {
                Console.WriteLine("Nova senha não condiz");
                Console.WriteLine("Você será redirecionado para a tela anterior");
                Console.ReadKey();
            }
            else
            {
                senhaAtual = new1;
                Console.WriteLine("Senha alterada com sucesso");
            }
        }
        Console.ReadKey();
        Console.Clear();

        return senhaAtual;
    }

    static void FecharCaixa()
    {
        Console.Clear();
        Console.WriteLine("Digite a senha atual para fechar o caixa: ");
        string senhaAtual = Console.ReadLine();


        if (senhaAtual == senhaAtual)
        {
            ListarProdutos();
            Console.WriteLine("\nFechando o caixa ... O programa será finalizado em 20 segundos.");
            Thread.Sleep(20000);
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Senha incorreta! Não é possível fechar o caixa");
            Console.ReadKey();
        }


    }
}
class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}