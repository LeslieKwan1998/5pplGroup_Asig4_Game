using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovebleAirState
{
  
    
    public IdleState(CenterController centerController)
    {
        this.centerController = centerController;
    }

    public override void beginFunc()
    {
        centerController.curForm = Form.normal;
       
    
        centerController.rotateArm.deactivate();
        centerController.playerAniClip("NormalIdle");
        
    }
    public override void excute()
    {
        base.excute();
        if (Input.GetKey(KeyCode.A))
            centerController.basicMoveMent.moveLeft();
        if (Input.GetKey(KeyCode.D))
            centerController.basicMoveMent.moveRight();

    }

    public override State tryTrans()
    {

        if (Input.GetKey(KeyCode.Space) && pausing == false)
        {
            
            return new IdleWithArmState(centerController); }
        if (Input.GetKey(KeyCode.J)&&!centerController.basicMoveMent.getJlocked())
        {
            return new JumpState(centerController);
        }
        //if (Input.GetKey(KeyCode.J)||Input.GetKey(KeyCode.K))
        //{
        //    return new JumpState(centerController);
        //}

        if (!centerController.state_isOnGround())
        {
            return new InAirUpState(centerController);
        }
        return this;
    }

}
