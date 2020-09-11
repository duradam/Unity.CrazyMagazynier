using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviourPun
{

    private void Update()
    {
        if (photonView.IsMine)
        {
            Camera.main.transform.localPosition = transform.position;
            Camera.main.transform.rotation = transform.rotation;
        }

    }
}
