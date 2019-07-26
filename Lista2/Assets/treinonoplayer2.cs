using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treinonoplayer2 : MonoBehaviour
{
    private float Speed;

    private int hp;

    public Texture sangueAzul;
    public Texture contornoDoSangue;

    public int vidaCheia=5;

    public int vidaDoPlayer;

    private int Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            if (value <= 0)
            {
                hp = 0;
                print("morreu");
                Destroy(GameObject);
            }  
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        hp = 5;
        vidaCheia = vidaDoPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        mover(); 

        if(vidaDoPlayer>=vidaCheia)
        {
            vidaDoPlayer = vidaCheia;
        } 
        else if(vidaDoPlayer<=0)
        {
            vidaDoPlayer = vidaCheia;
        }


    }
    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 25, Screen.height / 15, Screen.width / 5.5f/vidaCheia*vidaDoPlayer, Screen.height / 25),sangueAzul);
        GUI.DrawTexture(new Rect(Screen.width / 25, Screen.height / 15, Screen.width / 5.5f / vidaCheia * vidaDoPlayer, Screen.height / 25),contornoDoSangue);
    }

    public void mover()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        Vector3 direction = input.normalized;
        Vector3 velocity = direction * Speed;
        Vector3 moveAmont = velocity * Time.deltaTime;

        transform.Translate(moveAmont);
        
       

    }
    public void tomarDano(int dano)
    {
        hp -= dano;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("inimigo"))
        {
            other.GetComponent<Inimigo>().causarDano(this);
        } 
    }

}
