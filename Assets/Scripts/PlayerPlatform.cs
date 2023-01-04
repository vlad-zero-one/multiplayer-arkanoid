using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlatform : MonoBehaviourPun
{
    [SerializeField] private Text playerName;

    private void Start()
    {
        playerName.text = photonView.Owner.NickName;
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += Vector3.right;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += Vector3.left;
            }
        }
    }
}
