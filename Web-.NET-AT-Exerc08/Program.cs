using Web_.NET_AT_Exerc08.Data;
using Web_.NET_AT_Exerc08.Models;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        using (var db = new AppDbContext())
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Remover Cliente");
                Console.WriteLine("5. Sair");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCliente(db);
                        break;
                    case "2":
                        ListarClientes(db);
                        break;
                    case "3":
                        AtualizarCliente(db);
                        break;
                    case "4":
                        RemoverCliente(db);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }

    static void AdicionarCliente(AppDbContext db)
    {
        Console.WriteLine("Digite o nome do cliente:");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite o email do cliente:");
        var email = Console.ReadLine();
        Console.WriteLine("Digite o telefone do cliente:");
        var telefone = Console.ReadLine();

        var novoCliente = new Cliente { Nome = nome, Email = email, Telefone = telefone };
        db.Clientes.Add(novoCliente);
        db.SaveChanges();
        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    static void ListarClientes(AppDbContext db)
    {
        var clientes = db.Clientes.ToList();
        Console.WriteLine("Lista de Clientes:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}");
        }
    }

    static void AtualizarCliente(AppDbContext db)
    {
        Console.WriteLine("Digite o nome do cliente que deseja atualizar:");
        var nome = Console.ReadLine();
        var cliente = db.Clientes.FirstOrDefault(c => c.Nome == nome);

        if (cliente != null)
        {
            Console.WriteLine("Digite o novo telefone do cliente:");
            cliente.Telefone = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Telefone atualizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }

    static void RemoverCliente(AppDbContext db)
    {
        Console.WriteLine("Digite o nome do cliente que deseja remover:");
        var nome = Console.ReadLine();
        var cliente = db.Clientes.FirstOrDefault(c => c.Nome == nome);

        if (cliente != null)
        {
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            Console.WriteLine("Cliente removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado.");
        }
    }
}
