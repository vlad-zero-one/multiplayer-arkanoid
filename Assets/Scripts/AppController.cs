using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DependencyInjection;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Game
{
    public class AppController : MonoBehaviour
    {
        private ConnectionManager connectionManager;

        [SerializeField] private Logger logger;

        private void Awake()
        {
            DI.Add(logger);

            connectionManager = new ConnectionManager();
            PhotonNetwork.AddCallbackTarget(connectionManager);
            connectionManager.InitConnection();
            DI.Add(connectionManager);

        }

        public void ChangeScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}