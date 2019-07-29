using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    

    [SerializeField]


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision alvo)
    {
       if(alvo.CompareTag("player")
       {
            alvo.GetComponent<Player>().Invencibilidade(this);
       } 
    }

}
