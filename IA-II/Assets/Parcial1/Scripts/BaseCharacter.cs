using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter
{
    //---------------------------Stats------------------------------------
    protected int _hp;
    public int Hp { get { return _hp; } private set { _hp = value; } }

    protected int _maxHp;
    public int MaxHp { get { return _maxHp; } private set { _maxHp = value; } }

    protected float _speed;
    public float Speed { get { return _speed; } private set { _speed = value; } }

    protected int _damage;
    public int Damage { get { return _damage; } private set { _damage = value; } }

    //---------------------------Stats------------------------------------
    protected float _detectionPlayerRadius;
    public float DetectionPlayerRadius { get { return _detectionPlayerRadius; } private set { _detectionPlayerRadius = value; } }



}
