using System.Xml.Linq;

namespace ProjetoConsole;

class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Repository
{
    private List<Item> items = new List<Item>();
    private int nextId = 1;

    public void Create(string name)
    {
        items.Add(new Item { Id = nextId++, Name = name });
    }

    public List<Item> ReadAll()
    {
        return items;
    }

    public Item ReadById(int id)
    {
        return items.Find(item => item.Id == id);
    }

    public void Update(int id, string name)
    {
        Item existsItem = items.Find(item => item.Id == id);

        if (existsItem != null)
        {
            existsItem.Name = name;
        }
    }

    public void Delete(int id)
    {
        Item itemToRemove = items.Find(item => item.Id == id);

        if (itemToRemove != null)
        {
            items.Remove(itemToRemove);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Repository repository = new Repository();

        while (true)
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Criar Item");
            Console.WriteLine("2. Ler Todos os Itens");
            Console.WriteLine("3. Ler Item por Id");
            Console.WriteLine("4. Atualizar Item");
            Console.WriteLine("5. Deletar Item");
            Console.WriteLine("6. Sair");

            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Opção inválida.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Digite o nome do item:");
                    string name = Console.ReadLine();
                    repository.Create(name);
                    Console.WriteLine("Item criado com sucesso.");
                    break;

                case 2:
                    List<Item> allItems = repository.ReadAll();
                    foreach (var item in allItems)
                    {
                        Console.WriteLine($"Id: {item.Id}, Nome: {item.Name}");
                    }
                    break;

                case 3:
                    Console.WriteLine("Digite o Id do item:");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Item item = repository.ReadById(id);
                        if (item != null)
                        {
                            Console.WriteLine($"Id: {item.Id}, Nome: {item.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Item não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Id inválido.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Digite o Id do item a ser atualizado:");
                    if (int.TryParse(Console.ReadLine(), out int updateId))
                    {
                        Console.WriteLine("Digite o novo nome:");
                        string newName = Console.ReadLine();
                        repository.Update(updateId, newName);
                        Console.WriteLine("Item atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Id inválido.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Digite o Id do item a ser excluído:");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        repository.Delete(deleteId);
                        Console.WriteLine("Item excluído com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Id inválido.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Saindo da aplicação.");
                    return;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }
}