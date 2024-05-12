using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleSpawnerScript : MonoBehaviour
{
    public GameObject Obstacle;
    public Vector2 SpawnXCoordinates;
    public Vector2 SpawnYCoordinates;
    public Transform ObjectPoolParentTransform;
    public float RepeatRate;
    public bool FromLeft;

    public static ObstacleSpawnerScript ObstacleSpawner;
    public List<GameObject> ObjectPools;
    public int MaxObjectAmount;

    private void Awake()
    {
        ObjectPools = new List<GameObject>();
        for (var i = 0; i < MaxObjectAmount; i++)
        {
            var obj = Instantiate(Obstacle, new Vector3(0, SpawnYCoordinates.y + 5), Quaternion.identity);
            if (!FromLeft)
            {
                obj.GetComponent<SimpleMoveScript>().MoveToRight = false;
                Vector3 scale = obj.transform.localScale;
                scale.x *= -1;
                obj.transform.localScale = scale;
            }

            obj.SetActive(false);
            ObjectPools.Add(obj);
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), 0, RepeatRate);
    }

    private void SpawnObstacle()
    {
        var yPos = Random.Range(transform.position.y - 8, transform.position.y + 8);
        var obj = GetObjectFromPool();
        if (FromLeft)
            obj.transform.position = new Vector3(SpawnXCoordinates.x, yPos);
        else
            obj.transform.position = new Vector3(SpawnXCoordinates.y, yPos);
        obj.SetActive(true);
    }

    private GameObject GetObjectFromPool()
    {
        return ObjectPools.FirstOrDefault(x => x.activeInHierarchy == false);
    }
}
