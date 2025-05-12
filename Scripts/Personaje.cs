using UnityEngine;

public interface IAtacable
{
    void Attack(IRecibirDaño objetivo);
}

public interface IRecibirDaño
{
    void RecibirDaño(int cantidad);
}

public interface IDropearItems
{
    Item DropearItem();
}

public interface IMorir
{
    void Morir();
}

public abstract class Personaje : IAtacable, IRecibirDaño, IDropearItems, IMorir
{
    protected int vida;
    protected int ataque;
    protected int defensa;
    protected int durabilidad;

    public int Vida => vida;
    public int Ataque => ataque;
    public int Defensa => defensa;
    public int Durabilidad => durabilidad;

    public virtual void Attack(IRecibirDaño objetivo)
    {
        if (vida <= 0)
            throw new System.Exception($"{this.GetType().Name} está muerto.");
        if (durabilidad <= 0)
            throw new System.Exception($"{this.GetType().Name} no tiene arma usable.");

        int daño = Random.Range(5, ataque + 1);
        int desgaste = Random.Range(1, 4);

        durabilidad -= desgaste;
        objetivo.RecibirDaño(daño);
        Debug.Log($"{this.GetType().Name} ataca con {daño} de daño, [durabilidad restante: {durabilidad}]");
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
        if (vida < 0)
        {
            vida = 0;
        }

        Debug.Log($"{ this.GetType().Name} recibió " + cantidad + " de daño. Vida actual: " + vida);

        if (vida == 0)
        {
            Morir();
        }
    }


    public virtual Item DropearItem()
    {
        Debug.Log($"{this.GetType().Name} dropea un ítem.");
        return new Item();
    }

    public virtual void Morir()
    {
        Debug.Log($"{this.GetType().Name} ha muerto.");
    }
 
    
}