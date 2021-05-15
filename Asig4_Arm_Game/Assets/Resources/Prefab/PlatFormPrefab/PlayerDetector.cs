using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
   public bool isTriggered = false;
    [SerializeField]
    Rigidbody2D myRig;
    
    Rigidbody2D playerBody;


    private void Update()
    {
       
        if(myRig!=null&&playerBody!=null)
        {
            Debug.Log("set");
            playerBody.velocity += myRig.velocity;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTriggered = true;
            playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isTriggered = false;
            playerBody = null;
            //collision.gameObject.transform.SetParent(null);
        }
    }

}
