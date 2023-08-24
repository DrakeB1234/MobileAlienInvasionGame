using System.Collections;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacleObj;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float spawnDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnTimer");
    }

    IEnumerator SpawnTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnObstacle();   
        }
    }

    public void SpawnObstacle()
    {
        var obj = Instantiate(obstacleObj, gameObject.transform);
        obj.GetComponent<Obstacle>().speed = playerController.speed;
    }
}
