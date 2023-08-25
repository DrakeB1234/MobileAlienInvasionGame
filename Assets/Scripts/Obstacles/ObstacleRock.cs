using UnityEngine;

public class ObstacleRock : MonoBehaviour
{ 
    public float speed;

    private Animator animator;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerHealth>().TakeDamage();
            
            // Player destroyed animation, obj will be destroyed later by invoked method "Destroy" on Obstacle Mover
            animator.SetTrigger("Destroyed");
        }
    }
}
