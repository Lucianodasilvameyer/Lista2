using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject inimigoPrefab;


    List<Inimigo> listaInimigos = new List<Inimigo>(); 


    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy(new Vector2(Random.Range(3,8),Random.Range(4,2)));
        spawnEnemy(new Vector2(Random.Range(9, 1), Random.Range(5, 7)));
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void spawnEnemy(Vector2 position)
    {
        GameObject go = Instantiate(inimigoPrefab, position, Quaternion.identity);// o Quaternion.identity é para manter a mesma rotação
        go.GetComponent<Inimigo>().direction = (new Vector3(Random.Range(3, 8), Random.Range(4, 2)) - go.transform.position).normalized;
        listaInimigos.Add(go.GetComponent<Inimigo>());

        
    }

}
