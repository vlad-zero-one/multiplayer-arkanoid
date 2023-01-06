using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerPlatform playerPlatformPrefab;
        [SerializeField] private Ball ballPrefab;

        public void Spawn(int number)
        {
            var position = Vector2.zero;
            position.y = number == 1 ? -5 : 5;

            PhotonNetwork.Instantiate(playerPlatformPrefab.name, position, Quaternion.identity);

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity);
            }
        }
    }
}