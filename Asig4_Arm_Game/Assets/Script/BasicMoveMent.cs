using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveMent : MonoBehaviour, IBasicMoveMent
{

    bool _isEnable = true;
    bool _isActivate = false;
    Rigidbody2D rig;
    float moveSpeed = 5f;
    float jumpSpeed = 16f;
    CenterController centerController;
    public void activate()
    {
       _isActivate = true;
    }

    public bool isEnabled()
    {
        return _isEnable;
    }
   

    public void moveLeft()
    {
        rig.velocity = new Vector2( -moveSpeed, rig.velocity.y);
        centerController.isFaceToX = false;
        centerController.flip();
       
    }

    public void moveRight()
    {
        rig.velocity = new Vector2(moveSpeed, rig.velocity.y);
        centerController.isFaceToX = true;
        centerController.flip();
        
    }

 

    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        this.centerController = centerController;
        rig = centerController.getRig();
        _isEnable = true;
    }



   
   public  bool isActivate()
    {
        return _isActivate;
    }

    public void deactivate()
    {
        _isActivate = false;
    }

    public void Jump()
    {
        //   rig.AddForce(Vector2.up * 1000,ForceMode2D.Impulse);
        rig.velocity = new Vector2(rig.velocity.x, jumpSpeed);
    }
    public void SuperJump()
    {
        float superPower = 1.5F * jumpSpeed - Mathf.Abs( rig.velocity.y);
        if (superPower <= jumpSpeed/2)
            superPower = jumpSpeed/2;
        //   rig.AddForce(Vector2.up * 1000,ForceMode2D.Impulse);
        rig.velocity = new Vector2(rig.velocity.x, superPower);
    }

    public void SmallJump()
    {
        rig.velocity = new Vector2(rig.velocity.x, jumpSpeed/2);
    }
}
