using Unity.Cinemachine;
using UnityEngine;

public class SlimeLogic : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;
    private void Awake()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            CameraShake.instance.cameraShake(impulseSource);
        }
    }

}
