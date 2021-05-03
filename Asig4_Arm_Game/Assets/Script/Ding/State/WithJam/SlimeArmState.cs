using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeArmState : State
{

    CenterController centerController;

    public SlimeArmState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        centerController.slimeArm.activate();
    }
    public override void leaveState()
    {
        base.leaveState();
        centerController.slimeArm.deactivate();
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
        if (!Input.GetKey(KeyCode.K))
            return new IdleWithJamState(centerController);
        return this;
    }
}
