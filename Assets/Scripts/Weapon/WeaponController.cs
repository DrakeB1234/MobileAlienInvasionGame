using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Transform weaponSpawnPos;

    public GameObject[] weaponPrefabs;

    [HideInInspector]
    public GameObject currentWeaponObj;
    [HideInInspector]
    public Weapon currentWeaponScript;
    
    private void Awake()
    {
        // Start player with pistol
        var obj = Instantiate(weaponPrefabs[0], weaponSpawnPos);
        currentWeaponObj = obj;
        currentWeaponScript = currentWeaponObj.GetComponent<Weapon>();
    }   


    public void FireWeapon(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentWeaponScript.Fire();
        }
    }
}
