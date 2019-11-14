using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class TreinoNoGame3 : MonoBehaviour
{
    public float TempoDeSpawnarInimigoInicial;
    public float TempoDeSpawnarInimigoFinal;
    public float TaxaDeSpawn;
    public float timerMax;
    public float timerInicial;

    [SerializeField]
    private float pontuacaoInicio;

    [SerializeField]
    private float pontuacaoMax;

    [SerializeField]
    private float taxaDePontos;

    [SerializeField]
    private float Score;


    private GameObject PowerUpPrefab;

    private GameObject InimigoPrefab;
   

    [SerializeField]
    private float TempoDoPowerUpInicial;

    [SerializeField]
    private float TempoDoPowerUpFinal;

    List<TreinoNoInimigo3> ListaInimigos = new List<TreinoNoInimigo3>();
    List<Powerup> ListaPowerUps = new List<Powerup>();

    // Start is called before the first frame update
    void Start()
    {
        pontuacaoInicio = Time.time;
        TempoDeSpawnarInimigoInicial = Time.time;//coloco ele aqui?
    }

    // Update is called once per frame
    void Update()
    {
     
        if(Time.time>=TempoDoPowerUpInicial+TempoDoPowerUpFinal)
        {
            SpawnarPowerup();
        } 
        if(Time.time>=TempoDeSpawnarInimigoInicial+TempoDeSpawnarInimigoFinal)
        {
            TempoDeSpawnarInimigoInicial = Time.time;
            timerMax = TaxaDeSpawn;
        }
        if(Time.time>=timerInicial+timerMax)
        {
            timerInicial = Time.time;
            SpawnarInimigos(new Vector2(Random.Range(3, 5), (Random.Range(4, 9)));
            SpawnarInimigos(new Vector2(Random.Range(4, 7), (Random.Range(9, 8)));//??
        }
        if (Time.time >= pontuacaoInicio + pontuacaoMax)
        {
            pontuacaoInicio = Time.time;
            Score += taxaDePontos;
        }



    }
    public void SpawnarPowerup()
    {
        GameObject sis = Instantiate(PowerUpPrefab, new Vector3(Random.Range(0, 10), (Random.Range(0, 10)), Quaternion.identity);
        ListaPowerUps.Add(sis.GetComponent<TreinoNoGame3>());//??
    }
    public void SpawnarInimigos()
    {
        GameObject dis = Instantiate(InimigoPrefab,position, Quaternion.identity); //pq devo spawnar inimigos assim?
        dis.GetComponent<TreinoNoInimigo3>().direction = (new Vector3(Random.Range(3, 8), Random.Range(3, 4)) - dis.transform.position).normalized;
        ListaInimigos.Add(GetComponent<TreinoNoInimigo3>());
      

}*/
