using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : EntityBase
{
    protected bool isMoving;
    
    protected List<GameObject> foods = new List<GameObject>(); 
    public virtual void Move()
    {
        
    }
    protected virtual EntityBase SeekFood()
    {
        
        return null;
    }

    protected override void GetEntityInfo()
    {
        throw new System.NotImplementedException();
    }
}
