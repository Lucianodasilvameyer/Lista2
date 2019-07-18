using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0;
    // Start is called before the first frame update
    void Start()
    {

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
}
