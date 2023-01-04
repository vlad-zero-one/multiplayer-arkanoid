using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class PlayerPlatform : MonoBehaviourPun
    {
        [SerializeField] private Text playerName;

        private void Start()
        {
            SetName();
        }

        private void SetName()
        {
            playerName.text = photonView.Owner.NickName;
        }

        void Update()
        {
            if (photonView != null && photonView.IsMine)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    transform.position += Vector3.right;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    transform.position += Vector3.left;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    transform.position += Vector3.up;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    transform.position += Vector3.down;
                }
            }
        }
    }
}