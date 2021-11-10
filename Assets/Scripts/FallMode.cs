using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallMode : MonoBehaviour
{
    [SerializeField] private float zDisplacement, yDisp, xDisp, xRot, yRot, ZRot;


    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(xRot, yRot, ZRot);        
    }

    // Update is called once per frame
    void Update()
    {
        

            //    if (gameObject.tag != null)
            //    {
            //        transform.Translate(-xDisp * Time.deltaTime, -yDisp * Time.deltaTime, -zDisplacement * Time.deltaTime);
            //    }

            if (gameObject.tag == "first" )
        {
            iTween.RotateTo(gameObject, iTween.Hash("x", 90, "time", 10));
            transform.Translate(-xDisp * Time.deltaTime, -yDisp * Time.deltaTime, -zDisplacement * Time.deltaTime);
        }

        if (PlayerController.instance.isInSecond)
        {
            iTween.RotateTo(gameObject, iTween.Hash("x", 90, "time", 20));
        }

    }
}
