using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    bool isHit = false;
    Vector2 hitPosBuffer;
    public Vector2 veloBuffer;
    [SerializeField]
    Transform hitPos;
    [SerializeField]
    Rigidbody2D rig;
    public bool isHiting()
    {
        return isHit;
    }
    private void Start()
    {
        StartCoroutine(cleanBuffer());
    }
    public Vector2 getHitPos()
    {
        return hitPos.position;//need more detail
    }
    void beHit()
    {
        isHit = true;
    }
    void leaveHit()
    {
        isHit = false;
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlatForm" || collision.gameObject.tag == "Monster")
        {   beHit();
            updateMaxVelo(rig.velocity);
            hitPosBuffer = this.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "PlatForm" || collision.gameObject.tag == "Monster")
            leaveHit();
    }

    void updateMaxVelo(Vector2 velo)
    {
        if (velo.magnitude > veloBuffer.magnitude)
            veloBuffer = velo;
    }
    IEnumerator cleanBuffer()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            veloBuffer = Vector2.zero;
        }
    }
}
