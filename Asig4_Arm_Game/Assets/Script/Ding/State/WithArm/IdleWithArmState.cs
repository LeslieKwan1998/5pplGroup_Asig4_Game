using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleWithArmState : State
{
    CenterController centerController;
 
    public IdleWithArmState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {

        centerController.rotateArm.activate();
        centerController.rotateArm.stopRotate();
        centerController.playerAniClip("ArmIdle");
      
    }
    public override void excute()
    {
        base.excute();
        centerController.rotateArm.stopRotate();
      
    }
    public override void leaveState()
    {
        base.leaveState();
    
    }
    public override State tryTrans()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return new RotateMoveState(centerController);
        if (Input.GetKey(KeyCode.Space)&&pausing == false)
            return new IdleState(centerController);
        if (Input.GetKey(KeyCode.L) && pausing == false)
            return new BreakJamState(centerController);
        if (Input.GetKey(KeyCode.J) )
            return new HitState(centerController);
        if (Input.GetKey(KeyCode.K))
            return new ChargeArmState(centerController);
        return this;
    }

 
}