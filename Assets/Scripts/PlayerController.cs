using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public GameObject Player, Props_secondfloor , WinPanel, Confetti;
    public float sideVelocity, forwardVel;
    public Vector3 CameraPos;
    public Vector2 lastMousePosition;
    private Vector2 touchPosition;
    public bool GameFinished;
    public bool isInSecond;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameFinished)
        {
            transform.Translate(0, 0, forwardVel * Time.timeScale);
        }


        
    }
    private void FixedUpdate()
    {

        if (Input.GetKey("c"))
        {
            transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("v"))
        {
            transform.Translate(sideVelocity * Time.deltaTime, 0, 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {

            Vector2 deltaSwipe = touchPosition - (Vector2)Input.mousePosition;

            if ((Vector2)Input.mousePosition != lastMousePosition)
            {
                lastMousePosition = (Vector2)Input.mousePosition;

                if (deltaSwipe.x < 0)
                {
                    transform.Translate(sideVelocity * Time.deltaTime, 0, 0);
                }

                if (deltaSwipe.x > 0)
                {
                    transform.Translate(-sideVelocity * Time.deltaTime, 0, 0);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cupb"))
        {
            Player.GetComponent<Animator>().SetFloat("Jump Over Float", 1);
            Player.GetComponent<Animator>().SetTrigger("Jump Over");
            transform.Translate(0, 1, 0);
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

        if (other.CompareTag("Table"))
        {
            Player.GetComponent<Animator>().SetFloat("Jump Over Float", 6);
            Player.GetComponent<Animator>().SetTrigger("Jump Over");
            //transform.Translate(0, 1, 0);
        }
        if (other.CompareTag("thirdTable"))
        {
            Player.GetComponent<Animator>().SetFloat("Jump Over Float", 3);
            Player.GetComponent<Animator>().SetTrigger("Jump Over");
            //transform.Translate(0, 1, 0);
        }
        if (other.CompareTag("Finish"))
        {
            Player.GetComponent<Animator>().SetTrigger("PreviewTrail");
            GetComponent<Rigidbody>().isKinematic = true;
            GameFinished = true;
            StartCoroutine(ExecuteAfterTime(6));
            Confetti.SetActive(true);

            CameraShaker.Instance.enabled = false;
        }
    }

        private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("flight"))
        {
            Player.GetComponent<Animator>().SetBool("On Air", false);
            transform.Translate(0, -1, 0);
            Props_secondfloor.GetComponent<Animator>().enabled = true;
            isInSecond = true;
        }

        if (other.CompareTag("cupb"))
        {
            //Player.GetComponent<Animator>().SetFloat("Jump Over Float", 1);
            //Player.GetComponent<Animator>().SetTrigger("Jump Over");
            transform.Translate(0, -1, 0);
        }

        if (other.CompareTag("Table"))
        {
            //transform.Translate(0, -1, 0);
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        WinPanel.SetActive(true);

    }

}
