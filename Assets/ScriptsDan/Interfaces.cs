using UnityEngine;

public interface IDamageable
{
    //public abstract void TakeDamage();
    public void TakeDamage();
}

public interface IInteractable
{
    public void Interact();
}

public interface ICollectable
{
    public void Collect();
}
