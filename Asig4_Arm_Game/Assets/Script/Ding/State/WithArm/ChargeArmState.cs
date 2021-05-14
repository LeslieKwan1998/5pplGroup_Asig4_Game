using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArmState : State
{
    CenterController centerController;

    public ChargeArmState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        centerController.playerAniClip("Arm@Charge");
    }

    public override void excute()
    {
        base.excute();


    }
    public override State tryTrans()
    {
        Animator animator = centerController.playerAni;
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        // 判断动画是否播放完成
        if (info.normalizedTime >= 1.0f)
        {
            if(centerController.slimeArm.isGrabingThing())
            {
                centerController.slimeArm.deactivate();
                centerController.addChargingForce();
           
           }

          
           else if (centerController.getArmController().isHiting())
            {
                Debug.Log("addcharge");
            centerController.addChargingForce(); 
            }
            return new IdleWithArmState(centerController);
        }
        return this;
    }
}
