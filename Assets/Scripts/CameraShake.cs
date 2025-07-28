using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    [SerializeField] private float shakeForce = 1f;

    public void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    public void cameraShake(CinemachineImpulseSource source)
    {
        source.GenerateImpulseWithForce(shakeForce);
    }
}