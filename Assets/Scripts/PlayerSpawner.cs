using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerPlatform playerPlatformPrefab;

    public void Spawn(Vector2 position)
    {
        PhotonNetwork.Instantiate(playerPlatformPrefab.name, position, Quaternion.identity);
    }
}
