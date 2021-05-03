using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    CenterController centerController;
    
    public IdleState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
       
    
        centerController.rotateArm.deactivate();
        centerController.playerAniClip("NormalIdle");
    }
    public override void excute()
    {
        base.excute();
    
    }

    public override State tryTrans()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            return new BasicMoveState(centerController);
        if (Input.GetKey(KeyCode.Space)&&pausing ==false)
            return new IdleWithArmState(centerController);
        if (Input.GetKey(KeyCode.J))
        {
            return new JumpState(centerController);
        }
        if(!centerController.state_isOnGround())
        {
            return new InAirUpState(centerController);
        }
        return this;
    }

}
