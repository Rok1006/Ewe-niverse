using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloomRoot : EntityBase
{
    public override void Init()
    {
        base.Init();
        entityName = "GloomRoot";
    }
    public void Consume()
    {
        OnDeath();
    }

    protected override void GetEntityInfo()
    {
        throw new System.NotImplementedException();
    }
}
