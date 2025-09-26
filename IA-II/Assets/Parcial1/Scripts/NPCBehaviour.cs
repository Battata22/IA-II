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

    public void HealMe()
    {
        Hp += (int)(MaxHp * 0.5f);
    }

    public enum NPCType
    {
        passive, agressive, merchant, dead
    }
}
