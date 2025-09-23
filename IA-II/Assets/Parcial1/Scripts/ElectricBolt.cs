using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElectricBolt : MonoBehaviour
{
    //Lorenzo Solari

    [SerializeField] float electricDmg;
    [SerializeField] float jumpRange;
    [SerializeField] int maxBounces;
    BaseEnemy firstTarget;
    List<BaseEnemy> targetList;
    Transform target;

    void ElectricDamage()
    {
        hp -= electricDmg;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ElectricLighting();
        }
    }
    public void ElectricLighting()
    {
        var bounces = Enumerable.Range(0, maxBounces)
            .Select(bounces => closeEnemy)
            .Where(c => c.Hp > 0 && Vector3.Distance(transform.position, c.Position) <= jumpRange)
            .OrderBy(c => Vector3.Distance(firstTarget.Position, ))
            .ToList();          
    }
}
