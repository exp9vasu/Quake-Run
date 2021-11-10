using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 CameraPos;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        CameraPos = transform.position;
        offset = transform.position - Player.transform.position;
        //iTween.ShakePosition(gameObject, iTween.Hash("y", 1));
        CameraShaker.Instance.StartShake(5f,2f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.transform.position.x, CameraPos.y, Player.transform.position.z + offset.z - 1);

        //iTween.ShakePosition(gameObject, iTween.Hash("y", 1));
    }
}
