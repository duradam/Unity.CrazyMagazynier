using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Podnoszenie : MonoBehaviourPun
{
   
    public float speedMoving = 10f;
    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.E))
                transform.Translate(new Vector3(0, 1, 0) * speedMoving * Time.deltaTime, 0);
            if (Input.GetKey(KeyCode.D))
                transform.Translate(new Vector3(0, 1, 0) * -speedMoving * Time.deltaTime, 0);
        }
    }

}
