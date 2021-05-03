using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CenterController
{
     public bool state_judgIdle()
    {
        return Mathf.Abs(rig.velocity.x) <= 0.1f; 
    }

    public bool state_isOnGround()
    {
        //Vector2 pos = this.gameObject.transform.position;
        //float Xsize = this.gameObject.GetComponent<BoxCollider2D>().size.x;
        //float Ysize = this.gameObject.GetComponent<BoxCollider2D>().size.y;
        //Vector2 Lpos = new Vector2(pos.x - Xsize / 2, pos.y - Ysize / 2);
        //Vector2 Rpos = new Vector2(pos.x + Xsize / 2, pos.y - Ysize / 2);
        LayerMask mask = 1 << (LayerMask.NameToLayer("Player")) | 1 << (LayerMask.NameToLayer("Arm")) | 1 << (LayerMask.NameToLayer("UI"));

        mask = ~mask;
      
        RaycastHit2D lcast = Physics2D.Raycast(GroundCheckL.position, Vector2.down, 0.5f, mask);
        RaycastHit2D mcast = Physics2D.Raycast(GroundCheckM.position, Vector2.down, 0.5f, mask);
        RaycastHit2D rcast = Physics2D.Raycast(GroundCheckR.position, Vector2.down, 0.5f, mask);
        Debug.DrawLine(GroundCheckL.position, (Vector2)GroundCheckL.position + Vector2.down * 0.2f,Color.red);
    
        if (  rayCheck(lcast)  || rayCheck(mcast) || rayCheck(rcast))
        {
            return true;
        }
        return false;
    }

    bool rayCheck(RaycastHit2D hit)
    {
        if (hit.collider != null)
            if (hit.collider.tag != "Player" && hit.collider.tag != "Arm")
            {

                return true;
                
            }
        if (hit.collider != null)
            Debug.Log(hit.collider.name);
        return false;
    }
    public bool state_judgeDown()
    {
        return rig.velocity.y <= 0;
    }
}
