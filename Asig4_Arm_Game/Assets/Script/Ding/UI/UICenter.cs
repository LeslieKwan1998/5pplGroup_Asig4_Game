using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICenter : MonoBehaviour
{
    public static UICenter instance;

    public JamShower jamShower;
    [SerializeField]
    GameObject  JamShowerPrefab;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (instance != this)
            Destroy(this);
    }
    public void instanJamShower(CenterController centerController)
    {
        destroyJamShower();
        GameObject a = Instantiate(JamShowerPrefab);
       jamShower =a.GetComponent<JamShower>();
        Debug.Log(jamShower);
        jamShower.beCreat(centerController);
    }
    public void destroyJamShower()
    {
        if (jamShower != null&&jamShower.gameObject!=null ) 
        Destroy(jamShower.gameObject);
    }
}
