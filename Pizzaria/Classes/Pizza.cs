class Pizza
{
    //*atributos

    public int Id;
    public double Preco;
    public string Sabor;
    public string Tamanho;

    //#construtores
    public Pizza()
    {

    }
    public Pizza(int id, string sabor, string tamanho, double preco)
    {
        this.Id = id;
        this.Sabor = sabor;
        this.Tamanho = tamanho;
        this.Preco = preco;
    }

    public Pizza(string sabor, string tamanho, double preco)
    {
        this.Sabor = sabor;
        this.Tamanho = tamanho;
        this.Preco = preco;
    }
}