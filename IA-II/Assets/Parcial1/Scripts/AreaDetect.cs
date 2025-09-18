using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AreaDetect : MonoBehaviour
{
    [SerializeField] float waitTimer;
    [SerializeField] float range;
    
    void Start()
    {
        StartCoroutine(NPCDetection());
    }

   
    IEnumerator NPCDetection()
    {
        yield return new WaitForSeconds(waitTimer);

        Collider[] _baseCharacters = Physics.OverlapSphere(transform.position, range);

        if (_baseCharacters != null)
        {
            var c = _baseCharacters.Where(x => x.GetComponent<NPCBehaviour>())
                .Select(c => c.GetComponent<NPCBehaviour>())
                .OrderBy(v => Vector3.Distance(transform.position, v.transform.position));

            if (c.Any())

                foreach (var e in c)
                {
                    Debug.Log(e.name);
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
