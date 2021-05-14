using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveDir { leftToRight,rightToLeft,topToDown,DownToTop}
public delegate void  moveDele();
public class Moveble : MonoBehaviour
{
    [SerializeField]
    MoveDir moveDirection;

    [SerializeField]
    float changeDirFrequece;
    [SerializeField]
    float moveSpeed;

    float frequeceTimer;
    moveDele curMove;
    moveDele nextMove;
    Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
      switch(moveDirection)
        {
            case MoveDir.leftToRight:
                curMove = moveRight;
                nextMove = moveLeft;
            
                rig.constraints = RigidbodyConstraints2D.FreezePositionY +4;
                break;
            case MoveDir.rightToLeft:
                curMove = moveLeft;
                nextMove = moveRight;
                rig.constraints = RigidbodyConstraints2D.FreezePositionY+4;
                break;
            case MoveDir.topToDown:
                curMove = moveDown;
                nextMove = moveUp;
                rig.constraints = RigidbodyConstraints2D.FreezePositionX +4;
                break;
            case MoveDir.DownToTop:
                curMove = moveUp;
                nextMove = moveDown;
                rig.constraints = RigidbodyConstraints2D.FreezePositionX +4;
                break;
        }
    

    }

    // Update is called once per frame
    void Update()
    {
        frequeceTimer += Time.deltaTime;
        if(frequeceTimer>=changeDirFrequece)
        {
            frequeceTimer = 0;
            moveDele temp = curMove;
            curMove = nextMove;
            nextMove = temp;
        }
        curMove();

    }
    void moveLeft()
    {
        rig.velocity = new Vector2(-moveSpeed, 0);
    }

    void moveRight()
    {
        //this.gameObject.transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        rig.velocity = new Vector2(moveSpeed, 0);
    }
    void moveUp()
    {
        //this.gameObject.transform.position += new Vector3(0,moveSpeed * Time.deltaTime, 0);
        rig.velocity = new Vector2(0,moveSpeed);
    }
    void moveDown()
    {
        //this.gameObject.transform.position += new Vector3(0, -moveSpeed * Time.deltaTime, 0);
        rig.velocity = new Vector2(0,-moveSpeed);
    }
    

}