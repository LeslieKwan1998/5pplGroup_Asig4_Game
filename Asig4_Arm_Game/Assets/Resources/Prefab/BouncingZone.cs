using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingZone : MonoBehaviour
{
    [SerializeField]
    float boucingPower;
    [SerializeField]
    float moveDis = 10;
    float moveSpeed = 20f;
    float moveDisTimer = 0;

    float Ybuffer;
    bool isReadyToboucing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("et");
        if (collision.gameObject.tag == "Player"&&isReadyToboucing)
        {
            Rigidbody2D rig = collision.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(movePos());
            rig.velocity = Vector2.up * boucingPower; 
        }
    }
    IEnumerator movePos()
    {
        Ybuffer = this.transform.parent.position.y;
        while(moveDisTimer <= moveDis)
        {

               isReadyToboucing = false;
                this.transform.parent.position += new Vector3(0, moveSpeed * Time.deltaTime, 0);
                moveDisTimer += moveSpeed * Time.deltaTime;
                yield return new WaitForEndOfFrame();
         
          
        }
        moveDisTimer = 0;
        StartCoroutine(moveBack());


    }
    IEnumerator  moveBack()
    {
        while (this.transform.parent.position.y >= Ybuffer)
        {


            this.transform.parent.position -= new Vector3(0, moveSpeed * Time.deltaTime/2, 0);
         
            yield return new WaitForEndOfFrame();


        }


        isReadyToboucing = true;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
