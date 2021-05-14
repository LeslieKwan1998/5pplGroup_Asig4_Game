using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeArm : MonoBehaviour, ISlimeArm
{
    HingeJoint2D GrabJoint;
    CenterController centerController;
    float massBuffer;
    // Start is called before the first frame update
    bool isGrabMode = false;
    bool _isEnabled = false;
    void GrabThing(Rigidbody2D rigidbody2D)
    {
        if (GrabJoint!=null)
        { return; }
        GrabJoint =this.gameObject.AddComponent<HingeJoint2D>();
        GrabJoint.connectedBody = rigidbody2D;
        GrabJoint.anchor = new Vector2(0, 4.68f);
        massBuffer = centerController.getRig().mass;
        centerController.getRig().mass = 1;
        centerController.gameObject.transform.SetParent(rigidbody2D.gameObject.transform);
    }
    
    public bool isGrabingThing()
    {
        return GrabJoint != null;
    }

    void releaseThing()
    {
        if (GrabJoint != null)
            GrabJoint.breakForce = 0;
        centerController.gameObject.transform.parent = null;
        centerController.getRig().mass = massBuffer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isGrabMode)
            return;
        if (collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "PlatForm")
        {
            GrabThing(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }

  
    public void disableAbility()
    {
        _isEnabled = false;
        deactivate();
    }

    public void enableAbility(CenterController centerController)
    {

        this.centerController = centerController;
        massBuffer = centerController.getRig().mass;
        _isEnabled = true;
      
    }

    public bool isEnabled()
    {
        return _isEnabled;
    }

    public bool isActivate()
    {
        return isGrabMode;
    }

    public void activate()
    {
        isGrabMode = true;
        centerController.changeToJamSprite();
    }

    public void deactivate()
    {
        isGrabMode = false;
        releaseThing();
        centerController.changeToNomalSprite();
    }
}
