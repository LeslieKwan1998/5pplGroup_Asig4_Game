using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamHitState : State
{
    CenterController centerController;

    public JamHitState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {

    }

    public override State tryTrans()
    {
        throw new System.NotImplementedException();
    }
}

