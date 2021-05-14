using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackPower
{
    pa , dong,boom
}

public class EnemyController : MonoBehaviour
{
    CenterController centerController;

    [SerializeField]
    public  float speed;
    [SerializeField]
    public float guardFrequence;

    [SerializeField]
    public float chasingSpeed;

    [SerializeField]
    public float guardRange;
    [SerializeField]
    public float attckRange;
    [SerializeField]
    float defenceLevel;
    [SerializeField]
    float atk;
    [SerializeField]
    float atkCD;

    [SerializeField]
    GameObject attackArea;

    
    public float CDTimer;
    [HideInInspector]
    public float changeDirTimer = 0;
    [HideInInspector]
    public bool isMovingToleft = true;
    StateMachine<EnemyController> stateMachine;
    Rigidbody2D rig;
    [HideInInspector]
    public Animator ani;

    bool beHurtTrigger;
    // Start is called before the first frame update
    void Start()
    {
    
   
        centerController = GameObject.Find("Player").GetComponent<CenterController>();
        rig = this.GetComponent<Rigidbody2D>();
        ani = this.GetComponent<Animator>();
        StartCoroutine(startCDTimer());
        stateMachine = new StateMachine<EnemyController>(this, this, new EggGuardingState(this));
        stateMachine.excute();
        changeDirTimer = Random.Range(0f, 5f);
       
    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Debug.Log(stateMachine.getCurState());
    }


    public void moveToTarget()
    {
        if (centerController.gameObject.transform.position.x >= this.gameObject.transform.position.x)
            rig.velocity = new Vector2(chasingSpeed, rig.velocity.y);
        else
            rig.velocity = new Vector2(-chasingSpeed, rig.velocity.y);
    }

   public  void moveLeft()
    {

        rig.velocity = new Vector2(-speed, rig.velocity.y);
     
    }
   public  void moveRight()
    {
      
        rig.velocity = new Vector2(speed, rig.velocity.y);
    
    }

    public void attack()
    {
        CDTimer = atkCD;
        GameObject a = Instantiate(attackArea, this.gameObject.transform.position, this.gameObject.transform.rotation);
        a.GetComponent<AttackArea>().beCreat(this.GetComponent<BoxCollider2D>().size * 1.2f);
    }

   

    public bool state_hasEnemyInGuardRange()
    {
        if (((Vector2) centerController.gameObject.transform.position - (Vector2)this.gameObject.transform.position).magnitude <= guardRange)
            return true;

        return false;
    }
    public bool state_hasEnemeyInAttackRange()
    {
        if (((Vector2)centerController.gameObject.transform.position - (Vector2)this.gameObject.transform.position).magnitude <= attckRange)
            return true;
        return false;
    }
    public bool state_readyToAttack()
    {
        if (CDTimer > 0)
            return false;
        else
            return true;
    }
    public bool state_isHurt()
    {
      if(beHurtTrigger==true)
        {
            beHurtTrigger = false;
            return true;
        }
      else
        {
            return false;
        }
    }

    IEnumerator startCDTimer()
    {
        while(true)
        {
            if (CDTimer >= 0)
                CDTimer -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

    }
       public   IEnumerator guardProcess()
    {



        while(true)
        {
            changeDirTimer += Time.deltaTime;
            if (isMovingToleft)
                moveLeft();
            else
                moveRight();



            if (changeDirTimer >=guardFrequence)
            {
                changeDirTimer = 0;
                isMovingToleft = !isMovingToleft;

            }
            yield return new WaitForEndOfFrame();

        }



    }

    public void beHit(AttackPower attackPower)
    {



        if((int) attackPower>=defenceLevel)
        {
            beKill();
        }
        else
        {
            beHurt();
        }

    }

    void beHurt()
    {
        beHurtTrigger = true;
    }
    void beKill()
    {
        Destroy(this.gameObject);
    }
}

