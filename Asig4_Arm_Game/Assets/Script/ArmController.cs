using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    Rigidbody2D rig;
    HingeJoint2D joint;
    BoxCollider2D boxCollider;
    SpriteRenderer renderer;
    Sprite orignSprite;
    [SerializeField]
    public HitBox hitBox; // to detect whether this arm is hitng something
    [SerializeField]
    public Animator animator; // to detect whether this arm is hitng something
    // Start is called before the first frame update
    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();
        joint = this.GetComponent<HingeJoint2D>();
        renderer = this.GetComponentInChildren<SpriteRenderer>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        orignSprite = renderer.sprite;
    }
    public HingeJoint2D getJoint()
    {
        return joint;
    }
    public Rigidbody2D getRig()
    {
        return rig;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void showArm()   
    {
        //  this.gameObject.transform.localScale = orignScale;
        renderer.sprite = orignSprite;
        boxCollider.isTrigger = false;
    }
    public void hideArm()
    {
        //  this.gameObject.transform.localScale = Vector2.zero;
  

        renderer.sprite = null;
        boxCollider.isTrigger = true;
    }
    public bool isHiting()
    {
        return hitBox.isHiting();
    }
    public Vector2 getHitPos()
    {
        return hitBox.getHitPos();
    }

    }
