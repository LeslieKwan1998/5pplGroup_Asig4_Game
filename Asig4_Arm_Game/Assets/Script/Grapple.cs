using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour, IGrapple
{
    bool _isEnable;
    Rigidbody2D playerRig; 
    Rigidbody2D armRig; // hook head
    [SerializeField]
    float hookSpeed = 1000f;
    [SerializeField]
    float maxHoldTime = 1f;
    [SerializeField]
    GameObject GrappleHeadPrefab;
    GrappleHead grappleHead;
    Vector2 velocityBuffer;
    ArmController armController;
    public void disableAbility()
    {
        _isEnable = false;
    }

    public void enableAbility(CenterController centerController)
    {
        _isEnable = true;
        armRig = centerController.getArmController().getRig();
        playerRig = centerController.getRig();
        armController = centerController.getArmController();
    }

    public bool isEnabled()
    {
        return _isEnable;
    }

  

   public  void shootHook()
    {
        if(grappleHead!=null)
        { return; }

        armController.hideArm();
        GameObject headOB= Instantiate(GrappleHeadPrefab);
        headOB.transform.position = armRig.transform.position;
        headOB.transform.rotation = armRig.transform.rotation;
        grappleHead = headOB.GetComponent<GrappleHead>();
      
        Vector2 dir = armRig.transform.up.normalized; // shoot Direction
        velocityBuffer = dir * hookSpeed;
        grappleHead.shoot(velocityBuffer);
        //headRig.AddForce(dir * hookSpeed);
        StartCoroutine(waitForDash());
    }
   public  void retriveHook()
    {
        grappleHead.retreive();
        StartCoroutine(retreiveProcess());
    }
  public   void dashToHook()
    {

        StartCoroutine(dashProcess());
    }
   IEnumerator waitForDash()
    {
        float restTime = maxHoldTime;
       while(restTime>=0&&Input.GetKey(KeyCode.K))
        {

            yield return new WaitForEndOfFrame();

        }
       if(grappleHead!=null)
        {
            if(grappleHead.isGrabingSth()) // the hook grabed wall or platform, player dash to hook;
            {
                dashToHook();
            }
            else // the hook didnt grab anything, player retrieve hook;
            
            {
                retriveHook();
            }


        }
        else
        {
            Debug.LogError("no Head");
        }
    }
    IEnumerator dashProcess()
    {
        float flyingTime = grappleHead.flyingTime();
        
        float lastTime = 0;
        while( (playerRig.transform.position - grappleHead.transform.position).magnitude >= 1f && lastTime <= flyingTime  ) // Give player velocity until player reach hook head or time out
        {
            lastTime += Time.deltaTime;
            playerRig.velocity = velocityBuffer;
            yield return new WaitForEndOfFrame();

        }
        playerRig.velocity = Vector2.zero;
        armController.showArm(); 
        Destroy(grappleHead.gameObject);
    }
    IEnumerator retreiveProcess()
    {
        while (grappleHead != null)// wait until the grappleHead destroy
        {
            yield return new WaitForEndOfFrame();

        }
        armController.showArm();
    }
}
