using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Drugs : MonoBehaviour
{
    public GameObject playerScript;
    private bool collected = false;

    [SerializeField] private AudioSource pop;
    [SerializeField] private SpriteRenderer circle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && collected == false) 
        {

            playerScript = other.gameObject;
            StartCoroutine(Collection());

        }
    }

    public IEnumerator Collection() 
    {
        StartCoroutine(playerScript.gameObject.GetComponent<PlayerScript>().Drugs());
        pop.Play();
        circle.enabled = false;
        collected = true;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
