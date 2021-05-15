using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AbilityLocker : MonoBehaviour
{
    public UnLockAbility unLockAbility;
    public KeyCode keyCode;
    public string message;
    [SerializeField ]
    Text text;
    CenterController centerController;
    // Start is called before the first frame update
    bool isActivate = false;
    public bool ForceJump = false;
    void Start()
    {
       
        text.text = message;
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnGUI()
    {
        if (isActivate)
            if (Input.GetKeyDown(keyCode))
            {
                Time.timeScale = 1;
                if(ForceJump)
                {
                    centerController.basicMoveMent.forceJump();
                }
                Destroy(this.gameObject);
            }
    }

    void tutorious()
    {
      
        text.gameObject.SetActive(true);
        isActivate = true;
        switch(unLockAbility)
        {
            case UnLockAbility.jump:
                centerController.basicMoveMent.setJlock(false);
                break;
            case UnLockAbility.superJump:
                centerController.basicMoveMent.setKlock(false);
                break;
            case UnLockAbility.Charge:
                centerController.chargeArm.enableAbility();
                break;
            case UnLockAbility.Hit:
                centerController.landHit.enableAbility();
                break;
            case UnLockAbility.spetuala:
                centerController.rotateArm.enableAbility();
                break;



        }
        Time.timeScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            centerController = collision.gameObject.GetComponent<CenterController>();
            tutorious(); }
    }



}
public enum UnLockAbility
{
    jump,superJump,Hit,Charge,spetuala,nothing
}
