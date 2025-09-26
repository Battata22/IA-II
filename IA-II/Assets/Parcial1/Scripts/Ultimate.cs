using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    //Lorenzo Solari

    [SerializeField] float range;
    [SerializeField] float dmg;
    [SerializeField] float penal;
    [SerializeField] List<string> affected = new();
    PlayerBehaviour player;

    private void Start()
    {
        player = GetComponent<PlayerBehaviour>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            CastUltimate();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var x = LastAffectedList();
            foreach (var enemy in x)
            {
                print(enemy);
            }            
        }
    }

    IEnumerable<string> LastAffectedList()
    {
        if (affected.Count > 0)
        {
            foreach (var a in affected)
            {
                yield return (a);
            }
        }
        else
        {
            yield return "Empty";
        }
    }

    void CastUltimate()
    {
        Collider[] inRange = Physics.OverlapSphere(transform.position, range);

        var x = inRange.Where(x => x.GetComponent<BaseEnemy>())
            .Select(x => x.GetComponent<BaseEnemy>())
            .ToList();


        if (x.Any())
        {
            var tanks = x.Where(x => x.GetComponent<BaseEnemy>().EnemyType == EnemyType.Golem)
                .OrderByDescending(x => x.Hp)
                .ToList();

            var normals = x.Where(x => x.GetComponent<BaseEnemy>().EnemyType == EnemyType.Rat)
                .OrderByDescending(x => x.Hp)
                .ToList();

            if(tanks.Any())
            {
                foreach (var tank in tanks)
                {
                    tank.GetStuned();
                }                
            }
            if (normals.Any())
            {
                foreach (var normal in normals)
                {
                    normal.GetDamage(dmg);
                }
            }

            var affectedConcat = tanks.Concat(normals);
            affected = affectedConcat.Aggregate(new List<string>(), (acum, now) =>
            {
                acum.Add(now.name);
                return acum;
            });


        }
        else
        {
            player.GetDamage(dmg * penal);
            affected.Clear();
        }
    }
}
