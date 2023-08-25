using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform gunPointPos;

    public string weaponName;
    public int clipMax;
    public float reloadTime;
    public int reloadAmount;
    public int weaponDamage;

    private UIController uiController;
    private int clipSize;
    private bool reload;

    private void Awake() 
    {
        // Get uiController
        uiController = GameObject.Find("CanvasUI").GetComponent<UIController>();

        clipSize = clipMax;    
    }
    
    public int Fire()
    {
        if (!reload && clipSize > 0)
        {
            // Start reload caroutine
            reload = true;
            StartCoroutine("ReloadClip");
        }
        
        if (clipSize > 0)
        {
            clipSize--;

            // Update UI
            uiController.UpdateAmmo(clipSize);

            // Create projectile and gun point pos
            Instantiate(projectilePrefab, gunPointPos.position, Quaternion.identity);
        }

        return clipSize;
    }

    IEnumerator ReloadClip()
    {
        while (reload)
        {
            yield return new WaitForSeconds(reloadTime);

            if (clipSize != clipMax)
            {
                clipSize += reloadAmount;

                // Update UI
                uiController.UpdateAmmo(clipSize);
            }
            else
            {
                reload = false;
            }
        }
    }
}
