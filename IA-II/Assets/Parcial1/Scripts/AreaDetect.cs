using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AreaDetect : MonoBehaviour
{
    [SerializeField] float waitTimer;
    [SerializeField] float range;
    [SerializeField] NPCBehaviour[] _npcsInRange;
    
    void Start()
    {
        StartCoroutine(NPCDetection());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            var giveList = GiveList(_npcsInRange);

            foreach (var npc in giveList)
            {
                print(npc);
            }
        }
    }

    IEnumerable<string> GiveList(NPCBehaviour[] list)
    {
        foreach (var n in list)
        {
            yield return (n.name.ToString() + " Generator");
        }
    }


    IEnumerator NPCDetection()
    {
        yield return new WaitForSeconds(waitTimer);

        Collider[] _baseCharacters = Physics.OverlapSphere(transform.position, range);

        if (_baseCharacters != null)
        {
            //var c = _baseCharacters.Where(x => x.GetComponent<NPCBehaviour>())
            var c = _baseCharacters.Aggregate(new List<Collider>(), (acum, actual) =>
            {
                if (actual.GetComponent<NPCBehaviour>())
                {
                    acum.Add(actual);
                }

                return acum;

            })
                .Select(c => c.GetComponent<NPCBehaviour>());
                //.OrderBy(v => Vector3.Distance(transform.position, v.transform.position));

            _npcsInRange = c.ToArray();

            if (_npcsInRange.Any())

                foreach (var e in _npcsInRange)
                {
                    Debug.Log(e.name + " " + e.MaxHp);
                }
        }

        StartCoroutine(NPCDetection());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
