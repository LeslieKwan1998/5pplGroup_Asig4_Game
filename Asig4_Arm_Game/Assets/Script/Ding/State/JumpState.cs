﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovebleAirState
{


    public JumpState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {

        centerController.basicMoveMent.setKlock(false);
        centerController.basicMoveMent.setJlock(true);
        centerController.basicMoveMent.Jump();
        //  centerController.setPlayerAni("NormalJump");
        centerController.playerAniClip("NormalJump");
        centerController.playAudio("Jump",0.1f);
    }

    public override State tryTrans()
    {
        Animator animator= centerController.playerAni;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
            return new InAirUpState(centerController);
        if (Input.GetKey(KeyCode.K)&&!centerController.basicMoveMent.getKlocked())
            return new SuperJumpState(centerController);
        //if (Input.GetKey(KeyCode.K)||Input.GetKey(KeyCode.J ))
        //    return new SuperJumpState(centerController);
        if (Input.GetKey(KeyCode.Space) && centerController.rotateArm.isEnabled())
        {
            centerController.basicMoveMent.Jump() ;
            return new IdleWithArmState(centerController);
        }
        return this;
       
    }
}
