using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;

    private void Awake() 
    {
        Invoke("Destroy", lifeTime);    
    }

    private void Update() 
    {
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);    
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
