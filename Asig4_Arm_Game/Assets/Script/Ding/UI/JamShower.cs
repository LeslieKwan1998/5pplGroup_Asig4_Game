using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JamShower : MonoBehaviour
{
    CenterController modle;

    [SerializeField]
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void beCreat(CenterController centerController)
    {
        modle = centerController;
    }
    // Update is called once per frame
    void Update()
    {
     
        slider.value = modle.JamStateRestTime / modle.JamStateTime;
        if (slider.value <= 0.01f)
            Destroy(this.gameObject);
    }
    

}
