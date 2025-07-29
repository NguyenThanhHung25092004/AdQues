using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    private void Respawn()
    {
        Debug.Log("PlayersRespawned");
        Vector2 spawnPoint = RespawnManager.instance.lastCheckPoint;

        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        GameObject player2 = GameObject.FindGameObjectWithTag("Player2");

        if (player1 != null)
        {
            player1.transform.position = spawnPoint + new Vector2(-1f, 1f);
        }
        if (player2 != null)
        {
            player2.transform.position = spawnPoint + new Vector2(1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster") || other.gameObject.CompareTag("FallLimit"))
        {
            CameraShake.instance.cameraShake(impulseSource);
            Respawn();
        }
    }
}