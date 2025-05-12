using UnityEngine;

public interface IAtacable
{
    void Attack(IRecibirDa�o objetivo);
}

public interface IRecibirDa�o
{
    void RecibirDa�o(int cantidad);
}

public interface IDropearItems
{
    Item DropearItem();
}

public interface IMorir
{
    void Morir();
}

public abstract class Personaje : IAtacable, IRecibirDa�o, IDropearItems, IMorir
{
    protected int vida;
    protected int ataque;
    protected int defensa;
    protected int durabilidad;

    public int Vida => vida;
    public int Ataque => ataque;
    public int Defensa => defensa;
    public int Durabilidad => durabilidad;

    public virtual void Attack(IRecibirDa�o objetivo)
    {
        if (vida <= 0)
            throw new System.Exception($"{this.GetType().Name} est� muerto.");
        if (durabilidad <= 0)
            throw new System.Exception($"{this.GetType().Name} no tiene arma usable.");

        int da�o = Random.Range(5, ataque + 1);
        int desgaste = Random.Range(1, 4);

        durabilidad -= desgaste;
        objetivo.RecibirDa�o(da�o);
        Debug.Log($"{this.GetType().Name} ataca con {da�o} de da�o, [durabilidad restante: {durabilidad}]");
    }

    public void RecibirDa�o(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0)
        {
            vida = 0;
        }

        Debug.Log($"{ this.GetType().Name} recibi� " + cantidad + " de da�o. Vida actual: " + vida);

        if (vida == 0)
        {
            Morir();
        }
    }


    public virtual Item DropearItem()
    {
        Debug.Log($"{this.GetType().Name} dropea un �tem.");
        return new Item();
    }

    public virtual void Morir()
    {
        Debug.Log($"{this.GetType().Name} ha muerto.");
    }
 
    
}