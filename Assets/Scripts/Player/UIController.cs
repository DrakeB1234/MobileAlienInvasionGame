using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI distanceText;
    [SerializeField]
    private GameObject healthRow;
    [SerializeField]
    private GameObject healthImageObj;

    private PlayerHealth playerHealth;
    
    // Start is called before the first frame update
    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        // Add health objs to player UI
        for (int i = 0; i < playerHealth.lifeMax; i++)
        {
            Instantiate(healthImageObj, healthRow.transform);
        }
    }

    public void UpdateDistance(float distance)
    {
        distanceText.text = Mathf.Floor(distance) + " m";
    }

    public void UpdateHealth(int life)
    {
        var curVal = 0;
        foreach (Transform child in healthRow.transform)
        {
            if (curVal < life)
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            curVal++;
        }
    }
}
