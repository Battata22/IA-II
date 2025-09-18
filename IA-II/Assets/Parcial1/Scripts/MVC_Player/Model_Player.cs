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

    List<string> _kills = new();

    #region Fakes
    public void FakeStart()
    {
        _kills.Add("Primero");
        _kills.Add("Segundo");
        _kills.Add("Tercero");
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
            var c = _objectsInRange.Where(x => x.GetComponent<RatBehaviour>())
                .Select(c => c.GetComponent<RatBehaviour>())
                .OrderBy(v => v.Hp);

            if (c.Any(z => z.Hp < z.MaxHp * 0.1f))
            {
                var des = c.First();
                var obj = new { a = c.First().gameObject.transform, b = des.GetComponent<Renderer>().material, c = des.Hp, d = des.gameObject.name};
                _playerScript.destroyAlgo(des.gameObject);

                _kills.Add(obj.d);

                if (obj.b.color == Color.blue)
                {
                    Debug.Log("Mataste a una rata rara");
                }
                if (Vector3.Distance(obj.a.position, _playerScript.transform.position) == _playerScript.AoERadius)
                {
                    Debug.Log("Justo al limite");
                }
            }
        }
    }

    public IEnumerable<string> ReturnKills()
    {
        yield return _kills.First();
        _kills.RemoveAt(0);
    }

}
