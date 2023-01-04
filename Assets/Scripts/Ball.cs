using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Ball : MonoBehaviourPun
    {
        private Rigidbody2D rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();

            rigidbody.AddForce(Vector2.down * 500);
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //rigidbody.AddForce(Vector2.up);
        }

    }
}