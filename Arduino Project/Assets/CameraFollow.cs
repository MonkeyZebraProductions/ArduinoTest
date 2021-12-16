using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
 void Update()
    {

        Camera.main.transform.rotation = Quaternion.identity;
        Vector3.MoveTowards(Camera.main.transform.position,Player.position,1);
    }
}
