using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public float speed = 0;

    
    public int VidaDoplayer=5;

    public Texture sangueAzul;
    public Texture contornoDoSangue;
    public int Vidacheia=5;

   
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
        VidaDoplayer = Vidacheia;

        Hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if(VidaDoplayer>=Vidacheia)
        {
            VidaDoplayer = Vidacheia;
        }
        else if(VidaDoplayer<=0)
        {
            VidaDoplayer = 0;
        }


        andar();
    }
    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 25, Screen.height / 15, Screen.width / 5.5f/Vidacheia*VidaDoplayer, Screen.height / 25), sangueAzul);
        GUI.DrawTexture(new Rect(Screen.width / 40, Screen.height / 40, Screen.width / 5, Screen.height / 8), contornoDoSangue);
        

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
           

        } 
    }
    
}
