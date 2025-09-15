using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour, IPlayer
{
    //------------------------MVC-------------------------
    Model_Player _model;
    View_Player _view;
    Controller_Player _controller;

    //------------------------Life-------------------------
    [SerializeField] int _hp;
    public int Hp { get { return _hp; } private set { _hp = value; } }

    [SerializeField] int _maxHp;
    public int MaxHp { get { return _maxHp; } private set { _maxHp = value; } }

    //------------------------Combat-------------------------
    [SerializeField] float _damage;
    public float Damage { get { return _damage; } private set { _damage = value; } }

    [SerializeField] float _damageMultiplier;
    public float DamageMultiplier { get { return _damageMultiplier; } private set { _damageMultiplier = value; } }

    //------------------------Movement-------------------------
    [SerializeField] float _speed;
    public float Speed { get { return _speed; } private set { _speed = value; } }

    //[SerializeField] Rigidbody2D _rb;
    //public Rigidbody2D Rb { get { return _rb; } private set { _rb = value; } }
    [SerializeField] Rigidbody _rb;
    public Rigidbody Rb { get { return _rb; } private set { _rb = value; } }

    [NonSerialized] public float InputDirX, InputDirY;

    [SerializeField] bool _isGrounded = false;
    public bool IsGrounded { get { return _isGrounded; } private set { _isGrounded = value; } }

    [SerializeField] float _poundForce;
    public float PoundForce { get { return _poundForce; } private set { _poundForce = value; } }

    //------------------------MyData-------------------------
    [SerializeField] Material _matPlayer;
    public Material MatPlayer { get { return _matPlayer; } private set { _matPlayer = value; } }

    //------------------------Gameplay-------------------------
    [SerializeField] float _aoERadius;
    public float AoERadius { get { return _aoERadius; } private set { _aoERadius = value; } }


    [SerializeField] PlayerTeam _team;
    public PlayerTeam Team { get { return _team; } private set { _team = value; } }

    private void Awake()
    {
        MatPlayer = GetComponent<Renderer>().material;
        Rb = GetComponent<Rigidbody>();

        _model = new(this);
        _controller = new(this, _model);
        _view = new();

        SetMaxVariables();
    }

    private void Update()
    {
        _model.FakeUpdate();
        _controller.FakeUpdate();
        _view.FakeUpdate();

    }
    private void FixedUpdate()
    {
        _model.FakeFixedUpdate();
        _controller.FakeFixedUpdate();
        _view.FakeFixedUpdate();

    }


    private void OnTriggerEnter(Collider collision)
    {
        _controller.FakeOnTriggerEnter(collision);
    }

    public void SetGroundedFalse()
    {
        IsGrounded = false;
    }

    void SetMaxVariables()
    {
        Hp = MaxHp;
    }

    public Transform GetTransform()
    {
        return transform;
    }


    //-----------------------------Gizmos---------------------------------

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, _aoERadius);
    }

}
