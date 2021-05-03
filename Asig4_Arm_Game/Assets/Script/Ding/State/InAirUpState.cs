using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirUpState : State
{
    CenterController centerController;
    bool ableToSuperJump = true;

    public InAirUpState(CenterController centerController, bool ableToSuperJump = true)
    {
        this.centerController = centerController;
        this.ableToSuperJump = ableToSuperJump;
    }

    public override void beginFunc()
    {
        centerController.playerAniClip("NormalInAir_up");
    }

    public override State tryTrans()

    {
        if (Input.GetKey(KeyCode.K) && ableToSuperJump)
            return new SuperJumpState(centerController);
        if (Input.GetKey(KeyCode.Space)&&!pausing)
            return new IdleWithArmState(centerController);
        if (centerController.state_judgeDown())
            return new InAirDownState(centerController,ableToSuperJump);
        return this;
    }
}