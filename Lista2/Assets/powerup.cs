using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float tempoDeDestruicaoInicial;

    [SerializeField]
    private float tempoDeDestruicaoMax;


    // Start is called before the first frame update
    void Start()
    {
        tempoDeDestruicaoInicial = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= tempoDeDestruicaoInicial + tempoDeDestruicaoMax) 
        {
            Destroy(gameObject); //gameObject com g minusculo se refere a o objeto powerup  
                                 //não deve se usar o tempoDeDestruicaoInicial = time.time aqui pq cada powerup terá seu proprio timer          
        }
    }


}
