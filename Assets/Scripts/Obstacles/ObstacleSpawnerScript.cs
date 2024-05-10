using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject Obstacle;
    public Vector2 SpawnXCoordinates;
    public Vector2 SpawnYCoordinates;
    
    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0, 3f);
    }

    private void SpawnObstacle()
    {
        var yPos = Random.Range(SpawnYCoordinates.x, SpawnYCoordinates.y);
        Instantiate(Obstacle, new Vector3(SpawnXCoordinates.x, yPos), Quaternion.identity);
    }
}
