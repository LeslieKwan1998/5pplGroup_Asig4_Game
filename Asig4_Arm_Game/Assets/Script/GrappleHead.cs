using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHead : MonoBehaviour
{
    bool _isGrabingSth = false;
    float flyTime = 0;
    HingeJoint2D GrabJoint;
    Rigidbody2D rig;
    Vector2 velo;
    public bool isGrabingSth()
    {
        return _isGrabingSth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlatForm")
        {
            _isGrabingSth = true;
            GrabThing(collision.gameObject.GetComponent<Rigidbody2D>());
        }
    }
    void GrabThing(Rigidbody2D rigidbody2D)
    {
        if (GrabJoint != null)
        { return; }
        GrabJoint = this.gameObject.AddComponent<HingeJoint2D>();
        GrabJoint.connectedBody = rigidbody2D;

    }
  public   void shoot(Vector2 velo)
    {
        rig = this.GetComponent<Rigidbody2D>();
        rig.velocity = velo;
        this.velo = velo;
        StartCoroutine(flyTimer());
    }
    public float flyingTime() //get current flying time
    {

        return flyTime;
    }
    IEnumerator flyTimer()
    {
        while(true)
        {
            flyTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
   IEnumerator retrieveTimer(float flyedTime)
    {
        yield return new WaitForSeconds(flyedTime);
        Destroy(this.gameObject);
    }    
    public void retreive()
    {
        rig.velocity = -velo;
        StartCoroutine(retrieveTimer(flyTime));
    }

  
}
