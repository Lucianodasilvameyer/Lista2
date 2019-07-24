using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class treinonoplayer : MonoBehaviour
{
    public float speed;    //aqui não colocaria nenhuma variavel como [serializeField] pq o usuario pode acesa-las livremente durante o jogo? ja as variaveis do inimigo o usuario não pode acessar, por isso


    int VidaDoPlayer;

    public int hp;

    public int Hp
    {
        set
        {
            if (value <= 0)
            {
                hp = 0;
                Destroy(gameObject);
            }
        }
        get
        {
            return hp;

        }
    }
    private void mover()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        Vector3 direction = input.normalized;
        Vector3 velocity = speed * direction;
        Vector3 moveAmont = velocity * Time.deltaTime;

        transform.Translate(moveAmont);


    }




    // Start is called before the first frame update
    void Start()
    {
        Hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        mover();
    }
    public void TomarDano(int dano)
    {
        Hp -= dano;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("inimigo"))
        {
            other.GetComponent<Inimigo>().causarDano(this);//
        }
    }

}
