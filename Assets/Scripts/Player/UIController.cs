using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private Button pauseButton;
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private TextMeshProUGUI distanceText;
    [SerializeField]
    private GameObject healthRow;
    [SerializeField]
    private GameObject healthImageObj;
    [SerializeField]
    private GameObject ammoRow;
    [SerializeField]
    private GameObject ammoImageObj;

    private GameObject player;
    private PlayerHealth playerHealth;
    private Weapon weapon;
    
    private void Start()
    {
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        weapon = player.GetComponent<WeaponController>().currentWeaponScript;

        // Ensure pause menu is closed
        pauseUI.SetActive(false);

        // Add health objs to player UI
        for (int i = 0; i < playerHealth.lifeMax; i++)
        {
            Instantiate(healthImageObj, healthRow.transform);
        }

        // Add bulllet objs to player UI
        for (int i = 0; i < weapon.clipMax; i++)
        {
            Instantiate(ammoImageObj, ammoRow.transform);
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        resumeButton.Select();

        pauseUI.SetActive(true);
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseButton.Select();

        pauseUI.SetActive(false);
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

    public void UpdateAmmo(int clip)
    {
        var curVal = 0;
        foreach (Transform child in ammoRow.transform)
        {
            if (curVal < clip)
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
