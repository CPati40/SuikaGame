using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject[] slimesToSpawn;
    GameObject currentSlime, newSlime;
    public Rigidbody2D spawnerRB;
    Rigidbody2D currentSlimeRB;
    public float moveSpeed = 4;
    int random, nextRandom;
    bool canPress;
    Vector2 initialSpawnerPos;

    public UIController uIReference;

    // Start is called before the first frame update
    void Start()
    {
        initialSpawnerPos = transform.position;
        random = Random.Range(0, 5);
        StartCoroutine(NewSlimeCo());
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress)
        {
            spawnerRB.velocity = new Vector2(Input.GetAxis("Horizontal"), 0f) * moveSpeed;
            if (currentSlime.transform.parent != null)
                currentSlimeRB.velocity = spawnerRB.velocity;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                canPress = false;
                currentSlimeRB.gravityScale = 1f;
                currentSlimeRB.velocity = Vector2.zero;
                currentSlime.transform.parent = null;
                StartCoroutine(NewSlimeCo());
            }
        }
        else
        {
            spawnerRB.velocity = Vector2.zero;
            transform.position = initialSpawnerPos;
        }
            

    }

    private IEnumerator NewSlimeCo()
    {
        yield return new WaitForSeconds(1f);
        currentSlime = Instantiate(slimesToSpawn[random], transform.position, transform.rotation);
        currentSlimeRB = currentSlime.GetComponent<Rigidbody2D>();
        currentSlimeRB.gravityScale = 0f;
        currentSlime.transform.parent = transform;
        random = Random.Range(0, 5);
        uIReference.nextSlime.sprite = slimesToSpawn[random].GetComponent<SpriteRenderer>().sprite;
        canPress = true;
    }
}
