using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class ElectricBolt : MonoBehaviour
{
    //Lorenzo Solari

    [SerializeField] float electricDmg;
    [SerializeField] float jumpRange;
    [SerializeField] int maxBounces;
    int bouncesLeft;
    BaseEnemy firstTarget;
    List<BaseEnemy> targetList;

    private void Start()
    {
        bouncesLeft = maxBounces;
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
        //defino el area
        //pregunto si hay enemigos
        //agarro al mas cercano (where y vector.distance)
        //hacerle daño
        //matar al enemigo si no tiene vida
        //pregunto si hay otro enemigo cerca desde su posicion
        //repetir secuencia hasta que se acaben los saltos
        //
        //printeo
        StartCoroutine(Strike(transform, true));
    }

    IEnumerator Strike(Transform from, bool player = false)
    {
        bouncesLeft--;
        if(player)
        {
            Collider[] enemiesInRange = Physics.OverlapSphere(from.position, jumpRange);

            if (enemiesInRange.Any())
            {
                var c = enemiesInRange.Where(x => x.GetComponent<BaseEnemy>())
                    .Select(x => x.GetComponent<BaseEnemy>())
                    .OrderByDescending(x => Vector3.Distance(from.position, x.gameObject.transform.position))
                    .FirstOrDefault();
                if(c != null)
                {
                    var anonymous = new { a = c, b = Vector3.Distance(from.position, c.gameObject.transform.position) };
                    Debug.Log($"Daño aplicado a {anonymous.a.name}");

                    if (anonymous.b < jumpRange)
                    {
                        Debug.Log($"Alcance corto {anonymous.a.name}");
                    }
                    else
                    {
                        Debug.Log($"Alcance largo {anonymous.a.name}");

                    }

                    if (anonymous.a.TryGetComponent(out Material mat) && mat.color == Color.blue)
                    {
                        c.GetDamage(electricDmg * 2);
                        Debug.Log($"Daño aplicado: {(electricDmg * 2)}");
                    }
                    else
                    {
                        c.GetDamage(electricDmg);
                        Debug.Log($"Daño aplicado: {(electricDmg)}");
                    }
                    StartCoroutine(Strike(c.transform));
                }
                

            }
        }
        else
        {
            Collider[] enemiesInRange = Physics.OverlapSphere(from.position, jumpRange);

            if (enemiesInRange.Any())
            {
                var c = enemiesInRange.Where(x => x.GetComponent<BaseEnemy>())
                    .Select(x => x.GetComponent<BaseEnemy>())
                    .OrderByDescending(x => Vector3.Distance(from.position, x.gameObject.transform.position))
                    //.Skip(1)
                    .FirstOrDefault(x => x != this);
                var anonymous = new { a = c, b = Vector3.Distance(from.position, c.gameObject.transform.position) };
                Debug.Log($"Daño aplicado a {anonymous.a.name}");

                if (anonymous.b < jumpRange)
                {
                    Debug.Log($"Alcance corto {anonymous.a.name}");
                }
                else 
                {
                    Debug.Log($"Alcance largo {anonymous.a.name}");

                }
                Debug.Log($"Distancia {anonymous.b}");
                if (anonymous.a.TryGetComponent(out Material mat) && mat.color == Color.blue)
                {
                    c.GetDamage(electricDmg * 2);
                    Debug.Log($"Daño aplicado: {(electricDmg * 2)}");
                }
                else
                {
                    c.GetDamage(electricDmg);
                    Debug.Log($"Daño aplicado: {(electricDmg)}");
                }

                if(bouncesLeft > 0)
                StartCoroutine(Strike(c.transform));
            }
        }
        yield return null;
    }
}
