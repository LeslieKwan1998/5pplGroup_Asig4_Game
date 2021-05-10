using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CenterController : MonoBehaviour
{
    public IBasicMoveMent basicMoveMent;
    public  IRotateArm rotateArm;
    public ILandHit landHit;
    public IGrapple grapple;
    public ISlimeArm slimeArm;
    public ITeleporte teleporte;
    public IChargeArm chargeArm;
    Rigidbody2D rig;
    [SerializeField]
    ArmController armController;
    [SerializeField]
    public Animator playerAni;

    [SerializeField]
    public Transform GroundCheckL;
    [SerializeField]
    public Transform GroundCheckM;
    [SerializeField]
    public Transform GroundCheckR;
    [SerializeField]
    public float ChargingForce = 50f;
    [SerializeField]
    GameObject notifierPrefab;
    [SerializeField]
    public Transform savePoint;
    [SerializeField]
    bool startWithSpatula;

    public bool isFaceToX = true;
    

    // Start is called before the first frame update

    StateMachine<CenterController> stateMachine;
   public  Rigidbody2D getRig()
    {
        return rig;
    }
   public  ArmController getArmController()
    {
        return armController;
    }
    public IRotateArm getRotateArm()
    {
        return rotateArm;
    }

    void Start()
    {
        getComponents();
        getAbilities();
        if(!startWithSpatula)
        stateMachine = new StateMachine<CenterController>(this, this, new IdleState(this));
        else
            stateMachine = new StateMachine<CenterController>(this, this, new IdleWithArmState(this));
        stateMachine.excute();
    }

    void getAbilities()
    {   try
        {   basicMoveMent = this.GetComponentInChildren<IBasicMoveMent>();
            basicMoveMent.enableAbility(this);
            basicMoveMent.activate();
        }
        catch
        {
           
        }
        try
        {
            rotateArm = this.GetComponentInChildren<IRotateArm>();
            rotateArm.enableAbility(this);

            rotateArm.deactivate();
        }
        catch
        {

        }

        try
        {
            grapple = armController.GetComponentInChildren<IGrapple>();
            grapple.enableAbility(this);
        }
        catch
        {

        }
        try
        {
            landHit = this.GetComponentInChildren<ILandHit>();
            landHit.enableAbility(this);
        }
        catch
        {

        }
        try
        {
            slimeArm  = armController.GetComponent<ISlimeArm>();
            slimeArm.enableAbility(this);
            Debug.Log(slimeArm);
        }
        catch
        {
            Debug.LogError("No SlimeArm");
        }
        try
        {
            teleporte = this.GetComponentInChildren<ITeleporte>();
        }
        catch
        {

        }

        try
        {
            chargeArm = this.GetComponentInChildren<IChargeArm>();
        }
        catch
        {

        }
    


    }
    void getComponents()
    {
        rig = this.GetComponent<Rigidbody2D>();
      
       
    }
    // Update is called once per frame
    void Update()
    {
      //  playerInput();
      
        if (Input.GetKey(KeyCode.T))
        {
            
            Debug.Log("on" + state_isOnGround());
        }
      
    }

    void playerInput()
    {   
      
        //////if (Input.GetKey(KeyCode.S))
        //////{ rotateArm.rotateLeft();
        //////    Debug.Log("l");
        //////}
        //////if (Input.GetKey(KeyCode.W))
        //////{
        //////    rotateArm.rotateRight();
        //////    Debug.Log("r");
        //////}
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && rotateArm.isEnabled())
            rotateArm.stopRotate();
        if (Input.GetKeyDown(KeyCode.Space))
            swichMoveMent();
        //if (Input.GetKeyDown(KeyCode.W)&&slimeArm.isEnabled())
        //    slimeArm.activate();
        //if (!Input.GetKey(KeyCode.W)&&slimeArm.isEnabled())
        //    slimeArm.deactivate();
        if (Input.GetKey(KeyCode.K)&&grapple.isEnabled()&&rotateArm.isActivate())
            shootHook();
        if (Input.GetKeyDown(KeyCode.J) && landHit.isEnabled() && rotateArm.isActivate())
            attack();
        if (Input.GetKeyDown(KeyCode.J) && basicMoveMent.isActivate())
        {
            Debug.Log("jp");
            basicMoveMent.Jump(); 
        
        }
    }

  
   

    void moveLeft() // Move to left , the movement way depends on which ability is enabled
    {
     
        if (rotateArm.isEnabled()&&rotateArm.isActivate())
        {
            rotateArm.rotateLeft();
            //isAttacking = false;
        }
        else
        {
            basicMoveMent.moveLeft();
        }
    }
    void moveRight() // Move to right , the movement way depends on which ability is enabled
    {
        if (rotateArm.isEnabled() && rotateArm.isActivate())
        {
            rotateArm.rotateRight();
            //isAttacking = false;
        }
        else
        {
            basicMoveMent.moveRight();
        }
    }
    public void swichMoveMent() //Switch the movement way between rotating arm and walking
    {
   
        if(rotateArm.isEnabled())
        {
            if(basicMoveMent.isActivate())
            {
                basicMoveMent.deactivate();
                rotateArm.activate();
            }
            else
            {
                basicMoveMent.activate();
                rotateArm.deactivate();
            }

        }

    }

    public void shootHook()
    {

        grapple.shootHook();
    }
    public void attack()
    {
        landHit.Hit();
 
    }

    public void setPlayerAni(string tigger)
    {
        playerAni.SetTrigger(tigger);
    }
    public void playerAniClip(string name)
    {
        playerAni.Play(name);
 
    }
    public void flip()
    {
     
        if(this.gameObject.transform.localScale.x>0&&!isFaceToX)
        this.gameObject.transform.localScale =  new Vector3(-this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
        if (this.gameObject.transform.localScale.x < 0 && isFaceToX)
            this.gameObject.transform.localScale = new Vector3(-this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }
    
    public void addChargingForce()
    {
        Vector2 dir = armController.gameObject.transform.up;
        Vector2 force = -dir.normalized * ChargingForce;
        rig.AddForce(force, ForceMode2D.Impulse);
        Debug.Log("addforce");

    }

    public void showNotify(string message,Color color)
    {
        GameObject a = Instantiate(notifierPrefab, this.transform.position, this.transform.rotation);
        a.GetComponent<Notifier>().beCreat(message, color);
    }
    public void showNotify(string message, Color color,AttackPower attackPower)
    {
        GameObject a = Instantiate(notifierPrefab, this.transform.position, this.transform.rotation);
        a.GetComponent<Notifier>().showHit(message, color, attackPower);
    }

    public void dead()
    {
        rig.velocity = Vector2.zero;
        this.gameObject.transform.position = savePoint.position;

    }
}
