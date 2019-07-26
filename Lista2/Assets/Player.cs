using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField]
     float speed = 0;


    [SerializeField]
     int hpMax=5;

    [SerializeField]
    int hpInicial=1;

    [SerializeField]
    private float tempoInicialCura=1;

    [SerializeField]
    private float tempoFinalCura = 5;

    [SerializeField]
    private int taxaDeCura=1;//colocando 0. o valor multiplicado cai e 1. o valor multiplicado aumenta 
    [SerializeField]
    private int _hp;// sempre q usar o get e o set, deve-se criar a variavel private e a public
    public int Hp
    {

        get
        {
            return _hp;
        }
        set
        {



            if (value <= 0)
            {
                _hp = 0;
                print("morreu");
                sliderHp.value = 0;
                // Destroy(gameObject);
            }
            else if (value >= hpMax)
            {
                _hp = hpMax;
                sliderHp.value = 1;

                
            }
            else
            _hp = value; //
            sliderHp.value =(float) _hp / (float)hpMax;  //aqui o value é do tipo float e por isso é preciso passar o _hp e o hpMax para float
            //aqui tem q trabalhar com o objeto sliderHp criado pois a classe esta vazia?sim

        }
    }
    [SerializeField]
    Slider sliderHp;
   


    // Start is called before the first frame update
    void Start()
    {
        Hp = hpMax; //aqui indica q vai entrar no public Hp e o value se torna o valor do hpMax?
        
        tempoInicialCura = Time.time;
    }

    // Update is called once per frame
    void Update()
    {


        andar();


        if (Time.time >= tempoInicialCura + tempoFinalCura)
        {
            tempoInicialCura = Time.time;
            Hp+=taxaDeCura;
            
        }



    }
    private void andar()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);


        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;


        Vector3 moveAmount = velocity * Time.deltaTime;


        transform.Translate(moveAmount);
    }
    public void TomarDano(int dano)
    {
        
            Hp -= dano; 
        
    }
    

   





    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("inimigo"))
        {
            collision.GetComponent<Inimigo>().causarDano(this);
           

        } 
    }
    
}
