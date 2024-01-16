using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeSystem : MonoBehaviour
{
    public enum SlimeType { slime0, slime1, slime2, slime3, slime4, slime5, slime6, slime7, slime8, slime9 }

    public SlimeType slimeType;

    GameManager gMReference;

    // Start is called before the first frame update
    void Start()
    {
        gMReference = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Slime") && collision.gameObject.GetComponent<MergeSystem>().slimeType == slimeType)
        {
            Debug.Log("Merge");
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Instantiate(gMReference.slimes[(int)++slimeType], transform.position, transform.rotation);
        }
    }
}
