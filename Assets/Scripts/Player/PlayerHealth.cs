using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifeMax;
    [SerializeField]
    private UIController uiController;
    [SerializeField] 
    private float invincibleTimer;

    [HideInInspector]
    public int currentLife;

    private bool isInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = lifeMax;
    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            // Take damage
            currentLife--;

            uiController.UpdateHealth(currentLife);

            // Set invincible to true, start caroutine (timer) 
            isInvincible = true;
            StartCoroutine("StartInvincible");
        }
    }

    IEnumerator StartInvincible()
    {
        while (isInvincible)
        {
            yield return new WaitForSeconds(invincibleTimer);

            isInvincible = false;
        }
    }
}
