using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TreinoNoPlayer3 : MonoBehaviour
{
    private GameObject ShurikenPrefab;
    private GameObject EspadaPrefab;

    [SerializeField]
    private float CuraInicial;

    [SerializeField]
    private float CuraMax;

    [SerializeField]
    private float TaxaDeCura;



    [SerializeField]
    private float InvencibilidadeInicial;

    [SerializeField]
    private float InvencibilidadeMax;


    private TreinoNoInimigo3 TreinoNoInimigo3_ref;

    public bool Invencibilidade=false;

    [SerializeField]
    private float HpMax;

    [SerializeField]
    private int Speed;

    private int _hp;

    public int Hp
    {
        get
        {
            return _hp;     
        }
        set
        {
            if(value<=0)
            {
                _hp = 0;
                sliderHp.value = 0;
                Destroy(gameObject);
            }
            else if(value>=HpMax)
            {
                _hp = (int)HpMax;
                sliderHp.value = 1;
            }
            else
            {
                _hp = value;//?
                sliderHp.value = _hp / HpMax; 
            }
        }  


    }

    [SerializeField]
    Slider sliderHp;


    // Start is called before the first frame update
    void Start()
    {
        TreinoNoInimigo3_ref = GameObject.FindGameObjectWithTag("inimigo").GetComponent<TreinoNoInimigo3>();

        Hp = HpMax;

        CuraInicial = Time.time; //é preciso colocar aqui??
    }

    // Update is called once per frame
    void Update()
    {

        if (Invencibilidade == true)
        {
            if (Time.time >= InvencibilidadeInicial + InvencibilidadeMax)
            {
                toggleInvencibilidade();
            }
        }
        if(Time.time>=CuraInicial+CuraMax)
        {
            CuraInicial = Time.time;
            Hp += (int)TaxaDeCura;
        }


    }
    public void andar()
    {
        Vector2 Input;

        if(isplayer1)
        {
            new Vector2(Input.GetAxisRaw("horizontal"), Input.GetAxisRaw("vertical");
        }
        else
        {
            new Vector2(Input.GetAxisRaw("horizontal2"), Input.GetAxisRaw("vertical2");
        }
        Vector2 direction = Input.normalized;
        Vector2 velocity = Speed * direction;
        Vector2 moveAmont = velocity * Time.deltaTime;

        transform.Translate(moveAmont);
       
       
    }




    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.CompareTag("inimigo"))
        {
            collision.GetComponent<TreinoNoInimigo3>().CausarDano(this);
        }
        if(collision.CompareTag("CapaDeInvencibilidade"))
        {
            if(Invencibilidade==false)
            {
                InvencibilidadeInicial = Time.time;
                toggleInvencibilidade();
            }
        }
    }
    public void TomarDano(int dano)
    {
        Hp -= dano;
    }

    public void toggleInvencibilidade()
    {
        Invencibilidade = !Invencibilidade; 
    }
    public void UsarEspada()
    {
         if(Input.GetKeyDown(KeyCode.Q))
         {
            SpawnarEspada();
         }  
    }
    public void UsarShuriken()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnarShuriken();
        }
    }


    public void SpawnarEspada()
    {
        GameObject ris = Instantiate(EspadaPrefab, transform.position, Quaternion.identity);//é assim para espawnar a espada??

    }
    public void SpawnarShuriken()
    {
        GameObject sis = Instantiate(EspadaPrefab, transform.position, Quaternion.identity);
    }

}
