﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : State
{

    CenterController centerController;

    public HitState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {

        centerController.landHit.Hit() ;
    }
    public override void excute()
    {
        base.excute();
    }
    public override void leaveState()
    {
        Debug.LogError("leave");
        centerController.rotateArm.stopRotate();
    }

    public override State tryTrans()
    {
        if (centerController.getArmController().isHiting() == true)
        {
         
            return new IdleWithArmState(centerController); }
        return this;
    }
}