using System.Globalization;
static class Interfaces
{
    public static void showCadastrarPizza()
    {
        bool executing = true;
        while (executing)
        {

            Console.Clear();
            Console.WriteLine($"Cadastrar Pizza Selecionado\n");
            Console.WriteLine("Sabor da pizza");
            string sabor = Console.ReadLine();

            Console.WriteLine($"\nTamanho da pizza (G, M ou P)");
            string tamanho = Console.ReadLine();

            Console.WriteLine($"\nPreço da pizza");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            int id = Program.cardapio.IndexOf(Program.cardapio.Last()) + 1;

            Pizza pizzaNova = new Pizza(id, sabor, tamanho, preco);

            Services.setPizzaCardapio(pizzaNova);

            Console.WriteLine($"Deseja cadastrar mais uma pizza\nSim: 1\nNão:0");
            int resp = int.Parse(Console.ReadLine());

            executing = resp != 1 ? false : true;
        }

        Console.WriteLine($"Pizzas Cadastradas com sucesso, pressione enter para continuar...");
        Console.ReadLine();
    }

    public static void showCardapio()
    {
        Console.WriteLine($"\n----------CARDÁPIO----------");
        Program.cardapio.ForEach(pizza =>
        {

            Console.WriteLine($"Sabor:{pizza.Sabor} Tamanho:{pizza.Tamanho} Preço:{pizza.Preco.ToString("C")} Id:{pizza.Id}");
            Console.WriteLine($"_____________________________");
        });
    }
    public static void showAdicionais()
    {
        Console.WriteLine($"\n----------ADICIONAIS----------");
        Program.extras.ForEach(extra =>
        {

            Console.WriteLine($"Item:{extra.Item} Preço:{extra.Preco.ToString("C")} Id:{extra.ID}");
            Console.WriteLine($"_____________________________");
        });
    }

    public static void showNovoPedido()
    {
        var pizzas_selecionadas = new List<Pizza>();
        var adicionais_selecionadas = new List<Adicionais>();

        Console.WriteLine($"Novo pedido iniciado");
        Console.Write($"\nNome do Cliente:");
        string nomeCliente = Console.ReadLine();

        Console.Clear();
        Console.WriteLine($"\nVamos escolher um sabor, selecione a Pizza pelo ID:");
        bool executing = true;
        while (executing)
        {
            var pizzaEscolhida = new Pizza();
            Interfaces.showCardapio();
            Console.WriteLine($"Qual o Id da pizza ?");
            int id_pizza = int.Parse(Console.ReadLine());
            pizzaEscolhida = Services.getPizzaCardapio(id_pizza);
            pizzas_selecionadas.Add(pizzaEscolhida);

            Console.WriteLine($"Deseja adicionar mais uma pizza ? Sim:1 Nao: 2");
            int resp = int.Parse(Console.ReadLine());
            executing = resp != 1 ? false : true;
            Console.Clear();

        }

        Console.Clear();
        Console.WriteLine($"Deseja adicionar Extras ? Sim:1 Nao:0");
        int opt = int.Parse(Console.ReadLine());
        executing = opt != 1 ? false : true;
        while (executing)
        {
            var itemEscolhido = new Adicionais(); //
            Interfaces.showAdicionais();
            Console.WriteLine($"Qual o Id do item ?");
            int id_item = int.Parse(Console.ReadLine());
            itemEscolhido = Services.getItemAdicional(id_item);
            adicionais_selecionadas.Add(itemEscolhido);

            Console.WriteLine($"Deseja adicionar mais um item ? Sim:1 Nao: 2");
            int resp = int.Parse(Console.ReadLine());
            executing = resp != 1 ? false : true;

        }
        Console.Clear();

        Console.WriteLine($"Deseja remover alguma pizza da nota? Sim 1 Não 2");
        opt = int.Parse(Console.ReadLine());
        executing = opt != 1 ? false : true;
        while (executing)
        {
            for (int i = 0; i < pizzas_selecionadas.Count(); i++)
            {
                Console.WriteLine($"{pizzas_selecionadas[i].Sabor} {pizzas_selecionadas[i].Preco.ToString("C")} id {i}");
            }
            Console.WriteLine($"Qual o id da pizza que deseja remover ?");
            int id = int.Parse(Console.ReadLine());
            pizzas_selecionadas.RemoveAt(id);

            Console.WriteLine($"Deseja remover mais itens ? Sim 1 Não 2");
            opt = int.Parse(Console.ReadLine());
            executing = opt != 1 ? false : true;
        }

        Console.WriteLine($"Deseja remover alguma adicional da nota? Sim 1 Não 2");
        opt = int.Parse(Console.ReadLine());
        executing = opt != 1 ? false : true;
        while (executing)
        {
            for (int i = 0; i < adicionais_selecionadas.Count(); i++)
            {
                Console.WriteLine($"{adicionais_selecionadas[i].Item} {adicionais_selecionadas[i].Preco.ToString("C")} id {i}");
            }
            Console.WriteLine($"Qual o id do adicional que deseja remover ?");
            int id = int.Parse(Console.ReadLine());
            adicionais_selecionadas.RemoveAt(id);

            Console.WriteLine($"Deseja remover mais itens ? Sim 1 Não 2");
            opt = int.Parse(Console.ReadLine());
            executing = opt != 1 ? false : true;
        }

        string id_comanda = Services.setIdAleatório();
        var comanda = new NotaFiscal(id_comanda, nomeCliente, pizzas_selecionadas, adicionais_selecionadas);
        Program.notasFiscais.Add(comanda);
        Console.Clear();

        Console.WriteLine($"Pagar agora: 1 - Adicionar valor: 2 Pagar depois: 3");
        opt = int.Parse(Console.ReadLine());
        switch (opt)
        {
            case 1:
                string status = "";
                bool exec = true;
                var totalCliente = 0.0;

                while (exec)
                {
                    Console.Clear();
                    Console.WriteLine($"__________ NOTA FISCAL __________");
                    Console.WriteLine($"ID {comanda.ID_Nota}");
                    Console.WriteLine($"\nCliente {comanda.NomeCliente}");
                    Console.WriteLine($"__________ SUAS PIZZAS _________");
                    for (int i = 0; i < comanda.PizzasEscolhidas.Count; i++)
                    {
                        Console.WriteLine($"Sabor: {comanda.PizzasEscolhidas[i].Sabor} Tamanho: {comanda.PizzasEscolhidas[i].Tamanho} Preço: {comanda.PizzasEscolhidas[i].Preco.ToString("C")}");
                    }

                    Console.WriteLine($"__________ SEUS ADICIONAIS_________");
                    for (int i = 0; i < comanda.ItensAdicionais.Count; i++)
                    {
                        Console.WriteLine($"Item: {comanda.ItensAdicionais[i].Item} Preço:{comanda.ItensAdicionais[i].Preco.ToString("C")}");
                    }
                    comanda.ValorTotal = comanda.getTotalDaNota();
                    Console.WriteLine($"________ TOTAL _________");

                    while (exec)
                    {
                        Console.WriteLine($"{comanda.ValorTotal.ToString("C")} STATUS {status = comanda.Status}");
                        Console.WriteLine($"Valor pago pelo Cliente");
                        totalCliente = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        comanda.ValorTotal = comanda.ValorTotal - totalCliente;
                        exec = comanda.ValorTotal > 0 ? true : false;
                    }
                    comanda.Status = "PAGA";
                    Console.WriteLine($"STATUS {status = "PAGA"}");
                }
                break;

            case 2:
                totalCliente = 0.0;
                comanda.ValorTotal = comanda.getTotalDaNota();
                Console.WriteLine($"Qual o valor a ser adicionado ?");
                totalCliente = double.Parse(Console.ReadLine());
                comanda.ValorTotal -= totalCliente;
                break;

            case 3:
                comanda.ValorTotal = comanda.getTotalDaNota();
                Console.WriteLine($"Pagar depois...Enter para continuar:");
                Console.ReadLine();
                break;

        }
    }
    public static void showComanda()
    {
        Console.Clear();
        var exec = true;
        var comandas = Program.notasFiscais;

        Console.WriteLine($"COMANDAS ABERTAS");
        while (exec)
        {
            comandas.ForEach(comanda =>
            {
                if (comanda.Status == "EM ABERTO")
                {
                    Console.WriteLine($" ID: {comanda.ID_Nota} Cliente: {comanda.NomeCliente}");
                }

            });

            Console.WriteLine($"Qual o Id da Nota que deseja realizar o pagamento");
            var idBuscar = Console.ReadLine();

            for (var i = 0; i < comandas.Count; i++)
            {
                if (comandas[i].ID_Nota == idBuscar)
                {
                    Console.WriteLine($"Cliente: {comandas[i].NomeCliente}");
                    Console.WriteLine($"Total: {comandas[i].ValorTotal.ToString("C")}");
                    Console.WriteLine($"Status {comandas[i].Status}");

                    bool pag = true;

                    do
                    {
                        Console.WriteLine($"Qual o valor pago pelo cliente");
                        var total_cliente = double.Parse(Console.ReadLine());
                        comandas[i].ValorTotal -= total_cliente;
                        pag = comandas[i].ValorTotal > 0 ? true : false;

                        Console.WriteLine($"Total: {comandas[i].ValorTotal.ToString("C")}");
                        Console.WriteLine($"Status {comandas[i].Status = (pag == true ? "EM ABERTO" : "PAGO")}");

                    } while (pag);
                }

            };
            exec = false;
        }


    }
}