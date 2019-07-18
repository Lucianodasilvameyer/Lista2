using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    public Transform target;
    [SerializeField]
    public Vector3 direction;
    [SerializeField]
    protected float strength;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public virtual void Move()
    {

        Vector2 velocity = speed * direction * Time.deltaTime;
        transform.Translate(velocity);
    }


    public virtual void Init()
    {
        direction = target.position - transform.position;//transform.position é a posição do inimigo
        direction = direction.normalized;                 
    }
}
