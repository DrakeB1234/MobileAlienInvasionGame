using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    [SerializeField]
    private float speedMultiplier;
    
    [HideInInspector]
    public float speed;

    private void Start() 
    {
        // Set position of y to random value between min and max Y
        transform.position = new Vector2(transform.position.x, Random.Range(minY, maxY)); 

        Invoke("Destroy", destroyTime);  
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * speedMultiplier * Time.deltaTime, transform.position.y);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
