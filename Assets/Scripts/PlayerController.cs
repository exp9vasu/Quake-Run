using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Player;
    public float sideVelocity, forwardVel; 
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,forwardVel*Time.timeScale);

        if (Input.GetKey("c"))
        {
            transform.Translate(-sideVelocity*Time.deltaTime, 0, 0 );
        }
        if (Input.GetKey("v"))
        {
            transform.Translate(sideVelocity * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cupb"))
        {
            Player.GetComponent<Animator>().SetBool("nearTable", true);
        }

        if (other.CompareTag("landground"))
        {
            //Player.GetComponent<Animator>().SetBool("nearTable", false);
            //Player.GetComponent<Animator>().SetBool("isSliding", false);

        }
        if (other.CompareTag("slidetable"))
        {
            //Player.GetComponent<Animator>().SetBool("isSliding", true);
            Player.GetComponent<Animator>().SetFloat("Jump Over Float", 0);
            Player.GetComponent<Animator>().SetTrigger("Jump Over");
        }

        if (other.CompareTag("flight"))
        {
            Player.GetComponent<Animator>().SetFloat("On Air Float", 0);
            Player.GetComponent<Animator>().SetBool("On Air", true);
            transform.Translate(0, 1, 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("flight"))
        {
            Player.GetComponent<Animator>().SetBool("On Air", false);
            transform.Translate(0, -1, 0);
        }
    }

}
