// See https://aka.ms/new-console-template for more information


using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.WebSockets;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using static Program;

class Program
{
    // eu preciso de fazer um CRUD = criar, exibir, atualizar e deletar 
       //Faço uma class cliente 
    public class Cliente //Fazendo a classe Cliente 
    {
       public string nome { get; set; } // possível ler (get), possível atribuir valores (set).
       public int ID { get; set; }

        public Cliente(string nome, int ID) // construtor cliente
        {
            this.nome = nome; //objeto 'this.nome' para  propriedade 'nome' 
            this.ID = ID;
        }
        
        public void dadoscliente() //método de exibição de dados do cliente 
        {
            Console.WriteLine("Nome do cliente: "   + nome +   "ID do cliente:"   + ID);
        }
    }
    // opções da CRUD 
    static void Main(String[] args)
    {
        
        List<Cliente> clientes = new List<Cliente>(); //criação de lista dos clientes 


        int opcao; 

            do   // estrutura de repetição das determinadas chamadas a execução das funções 
            {
                 Console.WriteLine("MENU DE OPÇÕES");
                 Console.WriteLine(" 1 - PARA CRIAR CLIENTE");
                 Console.WriteLine(" 2 - PARA EXIBIR CLINTE");
                 Console.WriteLine(" 3 - PARA ATUALIZAR CLIENTE");
                 Console.WriteLine(" 4 - PARA DELETAR CLIENTE");
                 Console.WriteLine(" 5 - PARA SAIR");

              opcao = int.Parse(Console.ReadLine());

            switch (opcao) //estrutura de controle das determinadas execuções
                {
                case 1:
                    criarclientes(clientes); // função 'criar' clientes
                    break;
                case 2:
                    exibirclientes(clientes); // função 'exibir' clientes
                    break;
                case 3:
                    atualizarclientes(clientes); //função 'atualizar' clintes 
                    break;
                case 4:
                    deletarclientes(clientes); // função 'deletar' clientes 
                    break;
                case 5:
                    Console.WriteLine("saindo..."); 
                    break;

                default:                      
                    Console.WriteLine("\nDigite o número listado."); // opção não selecionada
                    break;
                }
                    Console.WriteLine("CLique no que Deseja.");
           
            } while (opcao != 5);
                        
    }

  
    static void criarclientes(List<Cliente> clientes) // função 'criar' clientes
    {
        Console.WriteLine("Digite o nome do novo Cliente:");
        string nome = Console.ReadLine();
        Console.WriteLine("/nDigite o Id do novo Cliente:");
        int ID = int.Parse(Console.ReadLine());
        Cliente cliente = new Cliente(nome, ID);
        clientes.Add(cliente);
        Console.WriteLine("\nNovo cliente adicionado com sucesso!!");
        
    }
        
    static void exibirclientes(List<Cliente> clientes)  // função 'exibir' clientes
    {
        Console.WriteLine("Aqui está a tabela de Clientes.");
        if (clientes.Count == 0)
        {
            Console.WriteLine("Não há clientes,adicione clientes");
            return;
        }
        
                    Console.WriteLine("Lista de Clientes");

        foreach(Cliente cliente in clientes)
        {
            cliente.dadoscliente();
        }
        
    }
    
    static void atualizarclientes(List<Cliente> clientes) // função 'atualizar' clintes 
    {
        Console.WriteLine("Digite o ID do cliente a atualizar");
        
        int ID = int.Parse(Console.ReadLine());
       
        Cliente cliente = clientes.Find(c=> c.ID ==  ID);


        if (cliente != null)
        {
            Console.WriteLine("Cliente encontrado :");
            cliente.dadoscliente();

            Console.WriteLine("\nDeseja mesmo atualizar esse cliente? n/s");
            string confirmacao = Console.ReadLine().ToLower();  
            if (confirmacao == "s")
            {
                Console.WriteLine("\nDigite o novo nome do cliente:");
                cliente.nome = Console.ReadLine();
                Console.WriteLine("\nCliente atualizado com sucesso!!");
            }
        }
        
    }
    
    static void deletarclientes(List <Cliente> clientes) // função 'deletar' clientes 
    {
        Console.WriteLine("Digite o ID do cliente que deseja deletar");
        int id = int.Parse(Console.ReadLine());
        Cliente cliente =  clientes.Find(c => c.ID == id);

        if (cliente != null)
        {
            clientes.Remove(cliente);
            Console.WriteLine("Cliente removido com sucesso!");
        }
        else 
        {
            Console.WriteLine("Cliente não removido, confira novamente o ID.");
        }
    }
}
