using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    // Start is called before the first frame update
   
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void beCreat(Vector2 size)
    {
        BoxCollider2D collider2D = this.GetComponent<BoxCollider2D>();
        collider2D.size = size;
        StartCoroutine(disaPear());

    }

    IEnumerator disaPear()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CenterController centerController = collision.gameObject.GetComponent<CenterController>();
            centerController.dead();
        }
        if (collision.gameObject.tag == "Monster")
        {
      

        }
    }
}
