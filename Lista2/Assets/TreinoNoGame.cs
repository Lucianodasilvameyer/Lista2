using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreinoNoGame : MonoBehaviour
{
    public GameObject inimigoPrefab;

    [SerializeField]
    private float taxaDePontos;

    [SerializeField]
    private float pontuacaoInicial;

    [SerializeField]
    private float pontuacaoMax;

    [SerializeField]
    private float TimerAumentoSpawn=1;

    [SerializeField]
    private float TimerAumentoSpawnMax=2;

    [SerializeField]
    private float TimerInicial=1.1f;

    [SerializeField]
    private float TimerMax=2;

    [SerializeField]
    [Range(0.05f,1f)]
    private float TaxaSpawn=0.25f;
  
    [SerializeField]
    private float score;

    public float _score
    {
        get
        {
            return _score;
        }
        set
        {
            if (value <= 0)
            {
                _score = 0;

            }
            else
                _score = value;

            textopontuacao.text = "pontuaçao" + _score;
        }
    }
    public TextMeshProUGUI textopontuacao;
    List<Inimigo> ListInimigos = new List<Inimigo>();


    // Start is called before the first frame update
    void Start()
    {
        pontuacaoInicial = Time.time;
        TimerAumentoSpawn = Time.time;
        TimerInicial = Time.time;
        _score = 0;    
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.time>=TimerAumentoSpawn+ TimerAumentoSpawnMax)
        {
            TimerAumentoSpawn = Time.time;
            TimerMax *= TaxaSpawn;
        }
        if(Time.time>=TimerInicial+TimerMax)
        {
            TimerInicial = Time.time;
            spawnarInimigo(new Vector2(Random.Range(2, 3), Random.Range(4, 3)));

        }
        if(Time.time>=pontuacaoInicial+pontuacaoMax)
        {
            pontuacaoInicial=Time.time;
            score += taxaDePontos;
        }

    }

    private void spawnarInimigo(Vector2 position)
    {
        GameObject fo = Instantiate(inimigoPrefab, position, Quaternion.identity);
        fo.GetComponent<Inimigo>().direction = (new Vector3(Random.Range(2, 3), (Random.Range(4, 5))) - fo.transform.position).normalized;
        ListInimigos.Add(fo.GetComponent<Inimigo>());
    }
}
