using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviourPun
{
    public Camera Camera;


    private void Update()
    {
        if (photonView.IsMine && Camera != null)
        {
            var pos = transform.position;
            pos.x -= 9.5f;
            pos.y += 10f;
            pos.z += 4.2f;
            Camera.transform.localPosition = pos;
        }

    }
}
