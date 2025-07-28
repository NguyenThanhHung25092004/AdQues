using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    public float spawnRate = 2f;
    private float spawnTime = 0;
    public Transform spawnPos;

    void spawnObstacles()
    {
        GameObject obstacle = ObstaclePool.instance.getObstacle();
        obstacle.transform.position = spawnPos.position;
        obstacle.transform.rotation = spawnPos.rotation;
    }

    private void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= spawnRate)
        {
            spawnObstacles();
            spawnTime = 0;
        } 
    }

}
