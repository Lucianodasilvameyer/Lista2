using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 0;

    [SerializeField]
    int VidaDoplayer;

   
    private int hp;
    public int Hp
    {

        get
        {
            return hp;
        }
        set
        {

            

            if (value<=0)
            {
                hp = 0;
                print("morreu");
                Destroy(gameObject);
            }

            hp = value;
        }
    }

    [SerializeField]
    TextMeshProUGUI vidaText;

    // Start is called before the first frame update
    void Start()
    {
        Hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        andar();
    }

    private void andar()
    {

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);


        Vector3 direction = input.normalized;

        Vector3 velocity = direction * speed;


        Vector3 moveAmount = velocity * Time.deltaTime;


        transform.Translate(moveAmount);
    }
    public void TomarDano(int dano)
    {
        
            Hp -= dano; 
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("inimigo"))
        {
            collision.GetComponent<Inimigo>().causarDano(this);
            Destroy(collision.gameObject);

        } 
    }
    
}
