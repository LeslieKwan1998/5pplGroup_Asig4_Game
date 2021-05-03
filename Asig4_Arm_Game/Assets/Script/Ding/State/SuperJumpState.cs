using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJumpState : State
{
    CenterController centerController;

    public SuperJumpState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        centerController.basicMoveMent.SuperJump();
        //centerController.setPlayerAni("NormalSuperJump");
        centerController.playerAniClip("NormalSuperJump");
    }

    public override State tryTrans()
    {
        Animator animator = centerController.playerAni;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
            return new InAirUpState(centerController,false);
        if (Input.GetKey(KeyCode.Space) && pausing == false)
        {
            centerController.basicMoveMent.SuperJump();
            return new IdleWithArmState(centerController); 
        
        }
        return this;
    }
}
