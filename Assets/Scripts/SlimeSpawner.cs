using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public Rigidbody2D spawnerRB;
    public float moveSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Hacemos que se mueva este objeto a una velocidad dada
        spawnerRB.velocity = new Vector2(Input.GetAxis("Horizontal"), 0f) * moveSpeed;
    }
}
