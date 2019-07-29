using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject shurikenPrefab;
    [SerializeField]
    private GameObject powerUpPrefab;

    [SerializeField]
    private float tempoDeDestruicaoInicial;

    [SerializeField]
    private float tempoDeDestruicaoMax;

    [SerializeField]
    shuriken shurikenX;
    

    [SerializeField]
    powerup powerupX; 

    [SerializeField]
    private float powerUpInicial;

    [SerializeField]
    private float powerUpMax;

    public GameObject inimigoPrefab;

    public static Game game;

    [SerializeField]
    protected Game game_ref;



    public GameObject gameOverText;


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
    List<powerup> listaPowerups = new List<powerup>();
    List<shuriken> listaShurikens = new List<shuriken>();

    // Start is called before the first frame update
    void Start()
    {
        tempoDeDestruicaoInicial = Time.time;
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
        if(Time.time>=tempoDeDestruicaoInicial+tempoDeDestruicaoMax)
        {
            tempoDeDestruicaoInicial = Time.time;
            DestruirPowerUp();
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
        gameOverText.enabled = true;
        gameOverText.gameObject.SetActive(true);
    }
    public void spawnarPowerUp()
    {
        GameObject sis = Instantiate(powerUpPrefab, position, Quaternion.identity);
        sis.GetComponent<powerup>().direction = (new Vector3(Random.Range(4.5), Random.Range(1.8))-sis.transform.position).normalized;
        listaPowerups.Add(sis.GetComponent<powerup>());
    }
    public void DestruirPowerUp()
    {
        Destroy("PowerUp");
    }
    public void Spawnarshuriken()
    {
        GameObject fit = Instantiate(shurikenPrefab, position, Quaternion.identity);
        fit.GetComponent<shuriken>().direction(new Vector3(-5.88), (1.63));
        listaShurikens.Add(fit.GetComponent<shuriken>());


    }
}
