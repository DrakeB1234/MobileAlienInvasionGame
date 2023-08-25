using System.Collections;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] obstacleObj;
    [SerializeField]
    private PlayerController playerController;
    [SerializeField]
    private float spawnDelay;

    private int obstacleObjLength;
    private bool isRockFlipped;
    
    // Start is called before the first frame update
    void Start()
    {
        obstacleObjLength = obstacleObj.Length;

        StartCoroutine("SpawnTimer");
    }

    IEnumerator SpawnTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnObstacleRocks();   
        }
    }

    public void SpawnObstacleRocks()
    {
        var genNum = Random.Range(0, obstacleObjLength);
        var obj = Instantiate(obstacleObj[genNum], gameObject.transform);
        obj.GetComponent<ObstacleMover>().speed = playerController.speed;

        // Randomly flip rocks
        if (isRockFlipped)
        {
            obj.transform.localScale = new Vector2(-1, 1);
        }

        isRockFlipped = !isRockFlipped;
    }
}
