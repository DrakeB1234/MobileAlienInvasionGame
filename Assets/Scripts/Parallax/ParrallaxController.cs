using UnityEngine;

public class ParrallaxController : MonoBehaviour
{
    [SerializeField]
    private float depth;
    [SerializeField]
    private float maxXPos;
    [SerializeField]
    private float minXPos;

    private PlayerController playerController;
    private float speed;

    private void Start() 
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        speed = playerController.speed;
    }

    private void Update() 
    {
        Vector2 pos = transform.position;
        pos.x -= speed / depth * Time.deltaTime;

        if (pos.x < minXPos)
            pos.x = maxXPos;

        transform.position = pos;
    }
}
