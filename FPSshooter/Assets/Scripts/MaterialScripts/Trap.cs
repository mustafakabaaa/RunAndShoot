using UnityEngine;

public class KinematicSwitch : MonoBehaviour
{
    private Rigidbody myRigidbody;

    void Start()
    {
        // Rigidbody bileþenini al
        myRigidbody = GetComponent<Rigidbody>();
        if (myRigidbody == null)
        {
            Debug.LogError("Rigidbody component not found on the object.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Eðer baþka bir collider içine girdiyse
        if (other.CompareTag("Player")) // Burada "Player" yerine kullanmak istediðiniz tag'i belirtin
        {
            // Rigidbody'nin isKinematic özelliðini false yap
            if (myRigidbody != null)
            {
                myRigidbody.isKinematic = false;
            }
        }
    }
}
