using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjection;
using Photon.Pun;

namespace Game
{
    public class DestroyableBlock : MonoBehaviourPun, IPunObservable
    {
        private bool isDestroyed = false;
        private Logger logger;

        private void Start() => logger = DI.Get<Logger>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == ObjectTags.Ball)
            {
                isDestroyed = true;
            }
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(isDestroyed);
            }

            if (stream.IsReading)
            {
                isDestroyed = (bool)stream.ReceiveNext();
            }
        }

        private void Update()
        {
            if (isDestroyed)
            {
                gameObject.SetActive(false);
            }
        }
    }
}