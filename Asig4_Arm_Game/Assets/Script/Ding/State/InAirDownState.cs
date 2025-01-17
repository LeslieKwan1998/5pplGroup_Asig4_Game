﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirDownState : MovebleAirState
{
    
    bool ableToSuperJump = true;
    public InAirDownState(CenterController centerController, bool ableToSuperJump = true)
    {
        this.ableToSuperJump = ableToSuperJump;
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        //centerController.setPlayerAni("NoarmalInAir_down");
        centerController.playerAniClip("NormalInAirDown");
    }

    public override State tryTrans()
    {
        if (Input.GetKey(KeyCode.K) && ableToSuperJump)
            return new SuperJumpState(centerController);
        //if ((Input.GetKey(KeyCode.K)||Input.GetKey(KeyCode.K) && ableToSuperJump))
        //    return new SuperJumpState(centerController);
        if (centerController.state_isOnGround())
            return new IdleState(centerController);
        if (Input.GetKey(KeyCode.Space) && pausing == false && centerController.rotateArm.isEnabled())
            return new IdleWithArmState(centerController);
        return this;
    }
}
