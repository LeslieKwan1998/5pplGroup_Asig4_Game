using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JamRotateMoveState : State
{
    CenterController centerController;

    public JamRotateMoveState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {

    }
    public override void excute()
    {
        base.excute();
        if (Input.GetKey(KeyCode.A))
            centerController.rotateArm.rotateLeft();
        if (Input.GetKey(KeyCode.D))
            centerController.rotateArm.rotateRight();
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && centerController.rotateArm.isEnabled())
            centerController.rotateArm.stopRotate();

    }


    public override State tryTrans()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && centerController.rotateArm.isEnabled())
            return new IdleWithJamState(centerController);
        if (Input.GetKey(KeyCode.J))
            return new HitState(centerController);
        if (Input.GetKey(KeyCode.K))
            return new SlimeArmState(centerController);
        if (Input.GetKey(KeyCode.Space) && pausing == false)
            return new IdleState(centerController);
        return this;

    }
}
