public class Adicionais
{
    public string Item;
    public double Preco;

    public int ID;

    public Adicionais()
    {

    }

    public Adicionais(string item, double preco, int id)
    {
        this.Item = item;
        this.Preco = preco;
        this.ID = id;
    }
    public Adicionais(string item, double preco)
    {
        this.Item = item;
        this.Preco = preco;
    }
}