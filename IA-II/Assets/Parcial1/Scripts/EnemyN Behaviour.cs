using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyNBehaviour : BaseEnemy, IDamageable
{

    protected override void Awake()
    {
        _hp = _maxHp;
    }

    protected override void Start()
    {

    }


    protected override void Update()
    {

    }


    public void GetDamage(float damage)
    {

    }
}
