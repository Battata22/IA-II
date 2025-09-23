using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyNBehaviour : BaseEnemy
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


    public override void GetDamage(float damage)
    {

    }
}
