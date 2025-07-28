using UnityEngine;

public class ObstacleLogic : MonoBehaviour
{
    public float obstacleSpeed = 5f;
    public float lifeTime = 10f;
    private float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        timer = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - obstacleSpeed * Time.deltaTime, transform.position.y);
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            ObstaclePool.instance.returnObstacle(gameObject);
        }
    }
}
