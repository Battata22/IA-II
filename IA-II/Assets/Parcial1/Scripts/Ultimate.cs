using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ultimate : PlayerBehaviour
{
    //Lorenzo Solari

    PlayerBehaviour player;
    [SerializeField] float range;
    [SerializeField] float failDmg;
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Collider[] ultRange = Physics.OverlapSphere(transform.position, range);

            if (ultRange != null)
            {
                var c = ultRange.Where(x => x.GetComponent<BaseEnemy>());
                    
                if (c.Any())
                {
                    ultRange.Select(x => x.GetComponent<BaseEnemy>())
                    .Select()
                }
                else
                {
                    player.Hp -= failDmg;
                }
            }

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
