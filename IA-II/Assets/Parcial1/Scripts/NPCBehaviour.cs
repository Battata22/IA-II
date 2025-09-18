using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : BaseCharacter
{
    public NPCType type;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public enum NPCType
    {
        passive, agressive, merchant, dead
    }
}
