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
    [SerializeField] List<(GameObject, float)> tupleList = new List<(GameObject, float)> ();
    [SerializeField] List<BaseEnemy> ordenados = new();
    void Start()
    {
        StartCoroutine(FireZone());
    }
    IEnumerator FireZone()
    {
        yield return new WaitForSeconds(fireTime);

        Collider[] _playerRange = Physics.OverlapSphere(transform.position, fireRange);

        if (_playerRange != null)
        {
            var c = _playerRange.Where(x => x.GetComponent<BaseEnemy>())
                .Select(y => y.GetComponent<BaseEnemy>());

            foreach (var e in c)
            {
                var ran = UnityEngine.Random.Range(1, dmg);
                e.GetDamage(ran);
                print(ran);
                tupleList.Add((e.gameObject, e.Hp));
            }
            c.OrderBy(c => c.Hp);
            ordenados = c.ToList();
            
        }

        foreach (var c in ordenados)
        {
            Debug.Log($"{c.name} tiene {c.Hp} de vida");
        }

        StartCoroutine(FireZone());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fireRange);
    }
}
