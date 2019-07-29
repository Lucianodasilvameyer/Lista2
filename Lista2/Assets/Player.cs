using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject espadaPrefab;
    [SerializeField]
    private GameObject shurikenPrefab;

    private float InvencibilidadeInicial;
    private float InvenciblilidadeMax;

    private bool invencivel=false;


    private Game gameRef;



    public bool gameOver=false;

    


    [SerializeField] //serve para as variaveis private aparecerem no inspector
    bool isPlayer1;

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
    private float taxaDeCura=0.5f;//colocando 0. o valor multiplicado cai e 1. o valor multiplicado aumenta 
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






                sliderHp.value = 0;
                Destroy(gameObject);
                Morte();

            }
            else if (value >= hpMax)
            {
                _hp = hpMax;
                sliderHp.value = 1;


            }
            else
            { 
              _hp = value;
                sliderHp.value = (float)_hp / (float)hpMax;  //aqui o value é do tipo float e por isso é preciso passar o _hp e o hpMax para float
            }                                               //se o value não for maior q o maximo ou menor q o minimo se usa a regra de 3 para descobrir seu valor 

            
            
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

        gameRef = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();//por este tipo de referencia qualquer função do script game pode ser usada no script player?sim, as publicas
    }

    // Update is called once per frame
    void Update()
    {
        // if(!gameOver)
        //{

           // segundos += Time.deltaTime;

            //if(segundos>=60)
            //{
              //  segundos = 0;
               // minutos++;
                //minutostext.text = minutos.ToString();
            //}
            //segundosToInt = (int)segundos;
            //segundostext.text = segundosToInt.ToString();

      //  }
        if(gameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //o SceneManager.GetActiveScene é para pegar a cena atual?


        }  
        andar();


        if (Time.time >= tempoInicialCura + tempoFinalCura)
        {
            tempoInicialCura = Time.time;
            Hp+=(int)taxaDeCura;
            
        }
        if (invencivel == true)
        {
            if (Time.time >= InvencibilidadeInicial + InvenciblilidadeMax)
            {

                toggleInvencibilidade();
            }
        }



    }
    private void andar()
    {
        Vector2 input;

        if(isPlayer1)
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal2"), Input.GetAxisRaw("Vertical2"));
        }
     


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
            if(!invencivel)
            collision.GetComponent<Inimigo>().causarDano(this);

            Destroy(collision.gameObject);
            

        }
        if(collision.CompareTag("CapaDeInvencibilidade"))
        {
            if (invencivel == false)
            {

                InvencibilidadeInicial = Time.time;//colocar aqui pq tem q começar a contar no momento q pegou
                toggleInvencibilidade();
            } 
        }
                  

    }


    public void Morte()
    {
        gameRef.GameOver();
        print("morreu");
    }
    private void toggleInvencibilidade()
    {
        invencivel = !invencivel;
        
    }

    private void AtacarComShuriken(Inimigo alvo)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Spawnarshuriken();
        } 
    }
    public void Spawnarshuriken()
    {
        GameObject fit = Instantiate(shurikenPrefab, transform.position, Quaternion.identity);

        
    }
    public void Spawnarespada()
    {
        GameObject rit = Instantiate(espadaPrefab, transform.position, Quaternion.identity);
       
        
    }



}

