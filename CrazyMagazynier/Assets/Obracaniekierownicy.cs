using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;

public class Obracaniekierownicy : MonoBehaviourPun
{

    void Update()
    {
        if (photonView.IsMine)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            transform.Rotate(new Vector3(0, h, 0));
        }
    }
}
