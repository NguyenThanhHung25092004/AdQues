using Unity.VisualScripting;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float offSetMultiplier = 1f;
    public float smoothTime = 0.05f;

    private Vector2 startPosition;
    private Vector3 velocity = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offSet = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(startPosition.x + offSet.x * offSetMultiplier, startPosition.y);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }
}
