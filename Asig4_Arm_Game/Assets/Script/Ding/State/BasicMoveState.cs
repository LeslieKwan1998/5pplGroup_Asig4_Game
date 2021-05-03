using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveState : State
{
    CenterController centerController;

    public BasicMoveState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        // centerController.setPlayerAni("NormalWalk");
        centerController.playerAniClip("NormalWalk");
    }

    public override State tryTrans()
    {
       if(centerController.state_judgIdle())
        {
            return new IdleState(centerController);
        }
       if(Input.GetKey(KeyCode.J))
        {
            return new JumpState(centerController);
        }
        if (Input.GetKey(KeyCode.Space) && pausing == false)
            return new IdleWithArmState(centerController);

        return this;
    }
    public override void excute()
    {
        base.excute();
        if (Input.GetKey(KeyCode.A))
            centerController.basicMoveMent.moveLeft();
        if (Input.GetKey(KeyCode.D))
            centerController.basicMoveMent.moveRight();
    }
}
