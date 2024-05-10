using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject Obstacle;
    public Vector2 SpawnXCoordinates;
    public Vector2 SpawnYCoordinates;
    public Transform ObjectPoolParentTransform;

    public static ObstacleSpawnerScript ObstacleSpawner;
    public List<GameObject> ObjectPools;
    public int MaxObjectAmount;

    private void Awake()
    {
        ObjectPools = new List<GameObject>();
        for (var i = 0; i < MaxObjectAmount; i++)
        {
            var obj = Instantiate(Obstacle, new Vector3(0, SpawnYCoordinates.y + 5), Quaternion.identity,
                ObjectPoolParentTransform);
            obj.SetActive(false);
            ObjectPools.Add(obj);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0, 3f);
    }

    private void SpawnObstacle()
    {
        var yPos = Random.Range(SpawnYCoordinates.x, SpawnYCoordinates.y);
        var obj = GetObjectFromPool();
        obj.transform.position = new Vector3(SpawnXCoordinates.x, yPos);
        obj.SetActive(true);
    }

    private GameObject GetObjectFromPool()
    {
        return ObjectPools.FirstOrDefault(x => x.activeInHierarchy == false);
    }
}
