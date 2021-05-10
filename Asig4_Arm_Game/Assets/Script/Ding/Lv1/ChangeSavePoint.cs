using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSavePoint : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform savePoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<CenterController>().savePoint = savePoint;
        }
    }

}
