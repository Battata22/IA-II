

using UnityEngine;

public interface IDamageable
{
    public void GetDamage(float damage);
}

public interface IPlayer
{
    public Transform GetTransform();
}

public interface IEnemy
{

}