using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject inimigoPrefab;

    [SerializeField]
    float inicioTimer=0.1f;
    [SerializeField]
    float timerMax = 2;
    [SerializeField]
    [Range(0.05f,1f)]
    float taxaSpawn=0.5f;

    [SerializeField]
    float timerAumentoSpawn=0.1f;
    [SerializeField]
    float timerAumentoSpawnMax=2;

    List<Inimigo> listaInimigos = new List<Inimigo>(); 


    // Start is called before the first frame update
    void Start()
    {
        inicioTimer = Time.time;
        timerAumentoSpawn = Time.time;


    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time>=inicioTimer+timerMax)
        {
            inicioTimer = Time.time;
            spawnEnemy(new Vector2(Random.Range(3, 8), Random.Range(4, 2)));
            spawnEnemy(new Vector2(Random.Range(9, 1), Random.Range(5, 7)));
        } 
        
        if(Time.time>=timerAumentoSpawn+timerAumentoSpawnMax)
        {
            timerAumentoSpawn = Time.time;
            timerMax *= taxaSpawn;

        }
    }

    void spawnEnemy(Vector2 position)
    {
        GameObject go = Instantiate(inimigoPrefab, position, Quaternion.identity);// o Quaternion.identity é para manter a mesma rotação
        go.GetComponent<Inimigo>().direction = (new Vector3(Random.Range(3, 8), Random.Range(4, 2)) - go.transform.position).normalized;
        listaInimigos.Add(go.GetComponent<Inimigo>());

        
    }
    
}
