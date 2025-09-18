using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : BaseCharacter, IEnemy
{

    protected EnemyType _enemyType;
    public EnemyType EnemyType { get { return _enemyType; } private set { _enemyType = value; } }

    protected bool _isChasingPlayer;
    public bool IsChasingPlayer { get { return _isChasingPlayer; } private set { _isChasingPlayer = value; } }

    protected Transform _targetTransform;
    public Transform TargetTransform { get { return _targetTransform; } private set { _targetTransform = value; } }


    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }



}
