class NotaFiscal
{
    //**atributos
    public string NomeCliente;
    public string ID_Nota;
    public List<Pizza> PizzasEscolhidas;
    public List<Adicionais> ItensAdicionais;
    public string Status = "EM ABERTO";
    public double ValorTotal = 0.0;

    public NotaFiscal(string id_comanda, string cliente, List<Pizza> pizzasEscolhidas, List<Adicionais> itensAdicionais)
    {
        this.ID_Nota = id_comanda;
        this.NomeCliente = cliente;
        this.PizzasEscolhidas = pizzasEscolhidas;
        this.ItensAdicionais = itensAdicionais;
    }

    public double getTotalDaNota()
    {
        double total = 0;
        if (PizzasEscolhidas.Count > 0)
        {
            for (int i = 0; i < PizzasEscolhidas.Count; i++)
            {
                total += PizzasEscolhidas[i].Preco;
            }
        }

        if (ItensAdicionais.Count > 0)
        {
            for (int i = 0; i < ItensAdicionais.Count; i++)
            {
                total += ItensAdicionais[i].Preco;

            }
        }

        return total;

    }

    public void getItensDaNota()
    {
        Console.WriteLine($"Pizza(s) Selecionada(s):");

        PizzasEscolhidas.ForEach(item => { Console.WriteLine($"Sabor: {item.Sabor} __ Tamanho: {item.Tamanho} __ Preco {item.Preco}"); });

        Console.WriteLine($"________________________");

        Console.WriteLine($"ItensAdicionais");

        ItensAdicionais.ForEach(item => { Console.WriteLine($"Adicional: {item.Item} __ Preco{item.Preco}"); });

        Console.WriteLine($"________________________");

    }
}