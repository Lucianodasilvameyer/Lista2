using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Player2 : MonoBehaviour
{
    



    private float segundos;
    private int segundosToInt;
    private int minutos;

    public Text minutostext;
    public Text segundostext;

    public bool gameOver = false;


    public GameObject GameOvertext;

    public TextMeshProUGUI textoGameOver2;

    [SerializeField]
    float speed2 = 0;


    [SerializeField]
    int hpMax2 = 5;

    [SerializeField]
    int hpInicial2 = 1;

    [SerializeField]
    private float tempoInicialCura2 = 1;

    [SerializeField]
    private float tempoFinalCura2 = 5;

    [SerializeField]
    private float taxaDeCura = 0.5f;//colocando 0. o valor multiplicado cai e 1. o valor multiplicado aumenta 
    [SerializeField]
    private int _hp2;// sempre q usar o get e o set, deve-se criar a variavel private e a public
    public int Hp2
    {

        get
        {
            return _hp2;
        }
        set
        {



            if (value <= 0)
            {
                _hp2 = 0;






                sliderHp2.value = 0;
                Destroy(gameObject);
                textoGameOver2.text = "GameOver";

            }
            else if (value >= hpMax2)
            {
                _hp2 = hpMax2;
                sliderHp2.value = 1;


            }
            else
                _hp2 = value; //
            sliderHp2.value = (float)_hp2 / (float)hpMax2;  //aqui o value é do tipo float e por isso é preciso passar o _hp e o hpMax para float
            //aqui tem q trabalhar com o objeto sliderHp criado pois a classe esta vazia?sim

        }
    }
    [SerializeField]
    Slider sliderHp2;



    // Start is called before the first frame update
    void Start()
    {
        Hp2 = hpMax2; //aqui indica q vai entrar no public Hp e o value se torna o valor do hpMax?

        tempoInicialCura2 = Time.time;
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
        //if (gameOver && Input.GetMouseButtonDown(0))
       // {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);    //o SceneManager.GetActiveScene é para pegar a cena atual?


       // }
        andar();


        if (Time.time >= tempoInicialCura2 + tempoFinalCura2)
        {
            tempoInicialCura2 = Time.time;
            Hp2 += (int)taxaDeCura;

        }





    }
    private void andar()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));



        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed2;


        Vector3 moveAmount = velocity * Time.deltaTime;


        transform.Translate(moveAmount);
    }
    public void TomarDano(int dano)
    {

        Hp2 -= dano;

    }








    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("inimigo"))
        {
            collision.GetComponent<Inimigo>().causarDano(this);


        }
    }


    public void Morte()
    {
        Game.game.GameOver();
        print("morreu");
    }
    private virtual void AtacarComEspada(Inimigo alvo)
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Game.Spawnarespada();
        }
    }




}

