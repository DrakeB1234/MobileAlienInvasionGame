using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int lifeMax;
    [SerializeField]
    private UIController uiController;


    [HideInInspector]
    public int currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = lifeMax;
    }

    public void TakeDamage()
    {
        // Take damage
        currentLife--;

        uiController.UpdateHealth(currentLife);
    }
}
