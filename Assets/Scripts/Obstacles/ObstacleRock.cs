using UnityEngine;

public class ObstacleRock : MonoBehaviour
{
    [SerializeField]
    private float destroyTime;
    [SerializeField]
    private float minY;
    [SerializeField]
    private float maxY;
    
    public float speed;

    private Animator animator;

    private void Start() 
    {
        animator = gameObject.transform.GetChild(0).GetComponent<Animator>();

        // Set position of y to random value between min and max Y
        transform.position = new Vector2(transform.position.x, Random.Range(minY, maxY)); 

        Invoke("Destroy", destroyTime);  
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
            
            // Player destroyed animation, obj will be destroyed later by invoked method "Destroy"
            animator.SetTrigger("Destroyed");
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
