using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjection;
using System;

namespace Game
{
    public class Ball : MonoBehaviourPun, IPunObservable
    {
        // TODO: bring this out to scriptable
        private const float VelocityMagnitude = 10f;
        private const float VelocityDifferencesOffset = 0.5f;

        private readonly Vector2 StartDirection = (Vector2.down + Vector2.right).normalized;

        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private Collider2D collider;

        private string platformName;

        private Logger logger;
        private float tickTime;

        private void Start()
        {
            logger = DI.Get<Logger>();

            if (!PhotonNetwork.IsMasterClient)
            {
                collider.enabled = false;
                Destroy(rigidbody);
            }
            else
            {
                rigidbody.velocity = StartDirection * VelocityMagnitude;

                StartCoroutine(SpeedControl());
            }
        }

        private IEnumerator SpeedControl()
        {
            while (this != null && gameObject != null)
            {
                yield return new WaitForSeconds(1f);
                var currentVelocity = rigidbody.velocity;

                //logger.Log(currentVelocity.magnitude.ToString());

                if (Mathf.Abs(currentVelocity.magnitude - VelocityMagnitude) > VelocityDifferencesOffset)
                {
                    if (currentVelocity.magnitude == 0)
                    {
                        currentVelocity = StartDirection;
                    }
                        
                    rigidbody.velocity = currentVelocity.normalized * VelocityMagnitude;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //platformName = collision.collider.gameObject.GetComponentInParent<PhotonView>().Owner.NickName;
            //logger.Log(platformName);
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {

            }

            if (stream.IsReading)
            {

            }
        }

    }
}