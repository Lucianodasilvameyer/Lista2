using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espada : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.CompareTag("inimigo")
        {
            Destroy(Inimigo);
        }
    }

}
