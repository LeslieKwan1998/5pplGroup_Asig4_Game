using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : MovebleAirState
{



    public HitState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        if(centerController.landHit.isEnabled())
        centerController.landHit.Hit() ;
    }
    public override void excute()
    {
        base.excute();
    }
    public override void leaveState()
    {

        centerController.rotateArm.stopRotate();
    }

    public override State tryTrans()
    {
        if (centerController.getArmController().isHiting() == true|| !centerController.landHit.isEnabled())
        {
           
            return new IdleWithArmState(centerController,true); }
        return this;
    }
}
