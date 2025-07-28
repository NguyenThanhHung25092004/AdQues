using Unity.Cinemachine;
using UnityEngine;

public class LeafParticleMove : MonoBehaviour
{
    public CinemachineCamera cam;
    void Start()
    {
        transform.position = cam.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.transform.position;
    }
}
