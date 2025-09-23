using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    //Lorenzo Solari

    [SerializeField] float fireTime;
    [SerializeField] float fireRange;
    [SerializeField] float dmg;
    void Start()
    {
        StartCoroutine(FireZone());
    }
    public void FireDmg(float dmg)
    {
        hp -= dmg;

    }
    IEnumerator FireZone()
    {
        yield return new WaitForSeconds(fireTime);

        Collider[] _playerRange = Physics.OverlapSphere(transform.position, fireRange);

        if (_playerRange != null)
        {
            var c = _playerRange.Where(x => x.GetComponent<BaseEnemy>())
                .Select(c => c.GetComponent<BaseEnemy>())
                .Select(c => c.FireDmg(dmg));
                var enemyData = new { enemyName = c.Name, enemyHp = c.Hp}
                .OrderBy(c => c.enemyHp)
                .ToList();               
        }

        Debug.Log($"Cantidad de enemigos afectados: ");
        foreach (var c in _playerRange)
        {
            Debug.Log($"{c.enemyName} tiene {c.enemyHp} de vida");
        }

        StartCoroutine(FireZone());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fireRange);
    }
}
