using UnityEngine;
using UnityEngine.Events;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    private int _value = 10;
    [SerializeField]
    private GameObject _pickupEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (_pickupEffectPrefab != null)
        {
            Instantiate(_pickupEffectPrefab, transform.position, transform.rotation);
        }

        GameManager.Instance.IncreaseScore(_value);

        Destroy(gameObject);
    }
}
