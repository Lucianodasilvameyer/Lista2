using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private float TempoDoPowerUpInicial;

    [SerializeField]
    private float TempoDoPowerUpFinal;




    // Start is called before the first frame update
    void Start()
    {
        TempoDoPowerUpInicial = Time.time;  
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>=TempoDoPowerUpInicial+TempoDoPowerUpFinal)
        {
            Destroy(gameObject);
        }
    }
}
