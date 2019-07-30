using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreinoNoInimigo3 : MonoBehaviour
{

    private TreinoNoPlayer3 treinoNoPlayer3_ref;

    [SerializeField]
    private float Strength;




    // Start is called before the first frame update
    void Start()
    {
        treinoNoPlayer3_ref = GameObject.FindGameObjectWithTag("Player").GetComponent<TreinoNoPlayer3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void CausarDano(TreinoNoPlayer3 alvo)
    {
       alvo.TomarDano((int)Strength);
    }
    public void OnCollisionEnter2D(Collision2D collision)//???
    {
        if(collision.CompareTag("Player") && TreinoNoPlayer3.Invencibilidade==false)//??
        {
            collision.CausarDano();//??
        }


    }

}
