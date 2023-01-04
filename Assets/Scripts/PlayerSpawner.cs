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

            if (PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                PhotonNetwork.Instantiate(ballPrefab.name, Vector2.zero, Quaternion.identity);
            }

            if (!PhotonNetwork.LocalPlayer.IsMasterClient)
            {
                StartCoroutine(DeleteBallPhysics());
            }
        }

        private IEnumerator DeleteBallPhysics()
        {
            var ball = FindObjectOfType<Ball>();

            while (ball == null)
            {
                yield return new WaitForSeconds(0.5f);
                ball = FindObjectOfType<Ball>();
            }

            Destroy(ball.gameObject.GetComponent<Rigidbody2D>());
            ball.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}