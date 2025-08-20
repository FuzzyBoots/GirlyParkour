using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pickuped up the powerup!");

        Destroy(gameObject);
    }
}
