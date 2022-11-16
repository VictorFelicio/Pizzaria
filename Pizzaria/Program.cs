class Program
{
    public static List<Pizza> cardapio = new List<Pizza>();
    public static List<Adicionais> extras = new List<Adicionais>();
    public static List<NotaFiscal> notasFiscais = new List<NotaFiscal>();
    public static void Main(string[] args)
    {
        Pizza pizzaTeste = new Pizza(0, "Queijo", "G", 20.00);
        cardapio.Add(pizzaTeste);

        Adicionais refrigerante = new Adicionais("Refrigerante", 8.00, 1);
        Adicionais borda = new Adicionais("Borda", 5.00, 2);
        extras.Add(refrigerante);
        extras.Add(borda);

        Console.Clear();
        bool executing = true;

        while (executing)
        {
            Console.WriteLine($"Pizzaria Florência");
            Console.WriteLine($"Para cadastrar uma nova pizza: 1\nPara iniciar um novo pedido: 2\nPara pagar uma comanda aberta: 3\nPara encerrar: 0");
            int option = int.Parse(Console.ReadLine());


            switch (option)
            {
                case 1:
                    Interfaces.showCadastrarPizza();
                    break;

                case 2:
                    Interfaces.showNovoPedido();
                    break;
                case 3:
                    Interfaces.showComanda();
                    break;

                default:
                    break;

            }

            Console.WriteLine($"Voltar ao menu:1 Finalizar:0");
            int resp = int.Parse(Console.ReadLine());
            executing = resp != 1 ? false : true;

        }

    }
};