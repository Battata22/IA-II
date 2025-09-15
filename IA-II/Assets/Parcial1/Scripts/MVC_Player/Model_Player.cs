using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Model_Player
{
    //Variables guardadas localmente
    PlayerBehaviour _playerScript;

    //Constructor para pedir variables
    public Model_Player(PlayerBehaviour playerScript)
    {
        //Asignado de variables solicitadas a las locales
        _playerScript = playerScript;
    }

    #region Fakes
    public void FakeStart()
    {

    }

    public void FakeUpdate()
    {

    }

    public void FakeFixedUpdate()
    {

    }

    public void FakeOnDestroy()
    {

    }
    #endregion

    public void Movement()
    {
        _playerScript.Rb.velocity = new Vector3(_playerScript.InputDirX, _playerScript.InputDirY, 0).normalized * _playerScript.Speed * Time.fixedDeltaTime;

    }

    public void Still()
    {
        if (_playerScript.Rb.velocity != Vector3.zero)
        _playerScript.Rb.velocity = new Vector3(0, 0, 0);
    }

    public void AoE()
    {
        Collider[] _objectsInRange = Physics.OverlapSphere(_playerScript.transform.position, _playerScript.AoERadius);

        if (_objectsInRange != null)
        {
            foreach (var o in _objectsInRange)
            {
                Debug.Log(o.name + " ANTES");
            }

            var _enemies = _objectsInRange.Where(_objectsInRange => _objectsInRange is IEnemy);

             foreach (var e in _enemies)
                Debug.Log(e.name);
        }
    }

}
