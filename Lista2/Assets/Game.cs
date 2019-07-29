using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    
    [SerializeField]
    private GameObject powerUpPrefab;

   


    [SerializeField]
    private float powerUpInicial;

    [SerializeField]
    private float powerUpMax;

    public GameObject inimigoPrefab;




    public TextMeshProUGUI gameOverText;


    [SerializeField]
    private float pontuacaoInicio=1;

    [SerializeField]
    private float pontuacaoMax=2;

    [SerializeField]
    private float taxaDePontos=1f;

    [SerializeField]
    float inicioTimer=1.1f;
    [SerializeField]
    float timerMax = 2; //tipo float?
    [SerializeField]
    [Range(0.05f,1f)]
    float taxaSpawn=0.25f;

    [SerializeField]
    float timerAumentoSpawn=1f;
    [SerializeField]
    float timerAumentoSpawnMax=2;
    [SerializeField]
    private float _score;// sempre q usar o get e o set, deve-se criar a variavel private e a public
    public float Score
    {

        get
        {
            return _score;
        }
        set
        {
            if(value<=0)
            {
                _score = 0;
            }
            else
            
            _score = value;


            textoPontuacao.text = "pontuação " + _score;
            

        }
    }



    public TextMeshProUGUI textoPontuacao;

    List<Inimigo> listaInimigos = new List<Inimigo>();
    List<Powerup> listaPowerups = new List<Powerup>();
   

    // Start is called before the first frame update
    void Start()
    {
        
        powerUpInicial = Time.time;
        pontuacaoInicio = Time.time;
        inicioTimer = Time.time;
        timerAumentoSpawn = Time.time;
        Score = 0;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timerAumentoSpawn + timerAumentoSpawnMax)
        {
            timerAumentoSpawn = Time.time;
            timerMax *= taxaSpawn;

        }

        if (Time.time>=inicioTimer+timerMax)
        {
            inicioTimer = Time.time;
            spawnEnemy(new Vector2(Random.Range(3, 8), Random.Range(4, 2)));
            spawnEnemy(new Vector2(Random.Range(9, 1), Random.Range(5, 7)));
        }

      

        if(Time.time>=pontuacaoInicio+pontuacaoMax)
        {
            pontuacaoInicio = Time.time;
            Score+=taxaDePontos;
        }

        if(Time.time>=powerUpInicial+powerUpMax)
        {
            powerUpInicial = Time.time;
            spawnarPowerUp();
        }
        
    }




    void spawnEnemy(Vector2 position)
    {
        GameObject go = Instantiate(inimigoPrefab, position, Quaternion.identity);
        go.GetComponent<Inimigo>().direction = (new Vector3(Random.Range(3, 8), Random.Range(4, 2)) - go.transform.position).normalized; //aqui o GetComponent pega o gameobject inimigo na variavel go e trabalha só com a direção dele?
        listaInimigos.Add(go.GetComponent<Inimigo>());         // pq subtrair pela posição do inimigo?
        

        
    }
   
    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
    }
    public void spawnarPowerUp()
    {
        GameObject sis = Instantiate(powerUpPrefab, new Vector3(Random.Range(0,10), Random.Range(0, 10)), Quaternion.identity);
       
        listaPowerups.Add(sis.GetComponent<Powerup>());
    }

    


}
