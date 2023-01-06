using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Ball : MonoBehaviourPun
    {
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private Collider2D collider;

        private void Start()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                collider.enabled = false;
                Destroy(rigidbody);
            }
            else
            {
                rigidbody.AddForce(Vector2.down * 500);
            }
        }

        private void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //rigidbody.AddForce(Vector2.up);
        }

    }
}