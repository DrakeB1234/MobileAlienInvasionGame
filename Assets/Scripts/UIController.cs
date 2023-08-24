using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI distanceText;

    private PlayerController player;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void UpdateDistance(float distance)
    {
        distanceText.text = Mathf.Floor(distance) + " m";
    }
}
