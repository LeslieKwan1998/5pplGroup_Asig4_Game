using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IdleWithJamState : State
{
    CenterController centerController;

    public IdleWithJamState(CenterController centerController)
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
    public override State tryTrans()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return new JamRotateMoveState(centerController);
        if (Input.GetKey(KeyCode.Space) && pausing == false)
            return new IdleState(centerController);
        if (Input.GetKey(KeyCode.L) && pausing == false)
            return new IdleWithArmState(centerController);
        //if (Input.GetKey(KeyCode.J))
        //    return new JamHitState(centerController);
        if (Input.GetKey(KeyCode.K))
            return new SlimeArmState(centerController);
        return this;
    }


}