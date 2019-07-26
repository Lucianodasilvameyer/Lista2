using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treinonoinimigo : MonoBehaviour
{
    [SerializeField]
    protected float Speed;  //aqui o protected é usado pois os filhos tambem teram speed e strength?sim
    [SerializeField]
    public Vector3 direction;
    [SerializeField]
    public Transform target;
    [SerializeField]
    protected float Strength;


    // Start is called before the first frame update
    void Start()
    {
        local(); //pq colocar esta função no start?, ela não se repetiria mais vezes?vão ter o alvo só uma vez
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    public virtual void move()
    {

        Vector2 velocity = Speed * direction * Time.deltaTime;   //o vector 2 velocity é o moveAmont 
        transform.Translate(velocity);        //para q colocar a velocity entre parenteses aqui?para passar o quanto ira se mover
    }

    public virtual void causarDano(treinonoplayer alvo)
    {
        alvo.TomarDano((int)Strength);
    }

    public virtual void local()
    {
        if (!target || target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; //pq usar o . transform?
        }

        direction = target.position - transform.position; // pq aqui a direção é a encontrada subtraindo a posição do alvo da posição do inimigo?
        direction = direction.normalized;
    }




}
