using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AblityCanvas : MonoBehaviour
{
    [SerializeField]
    Image FormImg;
    [SerializeField]
    Image Aabiliy;
    [SerializeField]
    Image Dability;
    [SerializeField]
    Image SpaceAbility;
    [SerializeField]
    Image Jability;
    [SerializeField]
    Image Kability;
    [SerializeField]
    CenterController model;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateImg();
    }

    void updateImg()
    {
      
        switch(model.curForm)
        {
            case (Form.normal):
                FormImg.sprite = load("NormalFormIcon");
                SpaceAbility.sprite = load("PullOut");
                state(SpaceAbility, model.rotateArm.isEnabled());


                Jability.sprite = load("Jump");
                state(Jability, !model.basicMoveMent.getJlocked());
                Kability.sprite = load("SJump");
                state(Kability, !model.basicMoveMent.getKlocked());

                Aabiliy.sprite = load("WalkLeft");
                Dability.sprite = load("WalkRight");
                break;
            case (Form.arm):
                FormImg.sprite = load("SpetualaForm");
                SpaceAbility.sprite = load("PullBack");

                Jability.sprite = load("LandHit");
                state(Jability, model.landHit.isEnabled());
                Kability.sprite = load("ReBound");
                state(Kability, model.chargeArm.isEnabled());

                Aabiliy.sprite = load("RotateLeft");
                Dability.sprite = load("RotateRight");
                break;

            case (Form.jam):
                FormImg.sprite = load("JamForm");
                SpaceAbility.sprite = load("PullBack");

                Jability.sprite = load("SlimeArm");
                state(Jability, model.slimeArm.isEnabled());
                Kability.sprite = load("ReBound");
                state(Kability, model.chargeArm.isEnabled());
           
                Aabiliy.sprite = load("RotateLeft");
                Dability.sprite = load("RotateRight");
                break;
        }
  
      



    }

    Sprite load(string s)
    {
        return Resources.Load<Sprite>("Icon/"+s);
    }
    void state(Image image,bool enabled= true)
    {
        if (!enabled)
            image.color = Color.gray;
        else
            image.color = Color.white;

    }

}
