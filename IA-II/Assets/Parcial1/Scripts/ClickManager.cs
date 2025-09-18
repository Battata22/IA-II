using System;
using System.Linq;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public float _grabRange;
    public bool _isGrabing;
    public PlayerBehaviour _player;
    public (BaseEnemy, Transform) tupla;


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var v3 = Input.mousePosition;
            v3.z = 10;
            v3 = Camera.main.ScreenToWorldPoint(v3);

            if (!_isGrabing)
            {
                var enemies = Physics.OverlapSphere(v3, _grabRange);

                var c = enemies.Where(x => x.GetComponent<BaseEnemy>())
                        .Select(c => c.GetComponent<BaseEnemy>())
                            .OrderBy(v => Vector3.Distance(v.transform.position, _player.transform.position));

                if (c.Any())
                {
                    tupla = (c.First(), c.First().transform);
                    _isGrabing = true;
                }
            }
            else
            {
                if (tupla.Item1.Hp <= 5)
                {
                    Destroy(tupla.Item1.gameObject);
                    _isGrabing = false;
                }
                else
                    tupla.Item2.position = v3;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isGrabing = false;
        }
    }
}
