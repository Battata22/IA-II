using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour 
{
    //---------------------------Stats------------------------------------
    [SerializeField] protected int _hp;
    public int Hp { get { return _hp; } protected set { _hp = value; } }

    [SerializeField] protected int _maxHp;
    public int MaxHp { get { return _maxHp; } protected set { _maxHp = value; } }

    [SerializeField] protected float _speed;
    public float Speed { get { return _speed; } protected set { _speed = value; } }

    [SerializeField] protected int _damage;
    public int Damage { get { return _damage; } protected set { _damage = value; } }

    //---------------------------Stats------------------------------------
    [SerializeField] protected float _detectionPlayerRadius;
    public float DetectionPlayerRadius { get { return _detectionPlayerRadius; } protected set { _detectionPlayerRadius = value; } }



}
