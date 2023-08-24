using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;

    public float speed;

    private void Start() 
    {
        Invoke("Destroy", destroyTime);  

        // Set position of y to random value between min and max Y
        transform.position = new Vector2(transform.position.x, Random.Range(minY, maxY)); 
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().TakeDamage();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
