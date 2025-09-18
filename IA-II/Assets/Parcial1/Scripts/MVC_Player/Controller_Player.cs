using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Player
{
    //Variables guardadas localmente
    PlayerBehaviour _playerScript;
    Model_Player _model;

    bool _moving = false;

    //Constructor para pedir variables
    public Controller_Player(PlayerBehaviour playerScript, Model_Player model)
    {
        //Asignado de variables solicitadas a las locales
        _playerScript = playerScript;
        _model = model;
    }

    #region Fakes
    public void FakeStart()
    {

    }

    public void FakeUpdate()
    {
        _playerScript.InputDirX = Input.GetAxisRaw("Horizontal");
        _playerScript.InputDirY = Input.GetAxisRaw("Vertical");

        if (_playerScript.InputDirX != 0  || _playerScript.InputDirY != 0)
        {
            _moving = true;
        }
        else
        {
            _moving = false;
            _model.Still();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _model.AoE();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            var test = _model.ReturnKills();
        }
    }

    public void FakeFixedUpdate()
    {
        if (_moving)
        {
            _model.Movement();
        }
    }

    public void FakeOnTriggerEnter(Collider collision)
    {

    }

    public void FakeOnDestroy()
    {

    }
    #endregion
}
