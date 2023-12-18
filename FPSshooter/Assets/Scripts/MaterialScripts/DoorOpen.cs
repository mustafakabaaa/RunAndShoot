using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public Vector3 normalPos;
    public Vector3 openPos;
    public float openSpeed = 5f;
    public bool isOpen = false;
    public float threshold = 0.01f; // Eþik deðeri
    [SerializeField] private AudioSource doorSound;

    void Update()
    {
        // Kapýnýn tamamen açýk veya kapalý olduðunu kontrol etmek
        float distanceToOpen = Vector3.Distance(transform.localPosition, openPos);
        isOpen = distanceToOpen < threshold;
    }

    public void OpenCloseDoor()
    {
        if (isOpen)
        {
            StartCoroutine(OpenDoorCoroutine(normalPos));
            Debug.Log("close");

        }
        else
        {
            StartCoroutine(OpenDoorCoroutine(openPos));
            Debug.Log("open");
            
        }
    }

    IEnumerator OpenDoorCoroutine(Vector3 targetPos)
    {
        float elapsedTime = 0f;
        Vector3 initialPos = transform.localPosition;
        doorSound.Play();
        while (elapsedTime < 1f)
        {
            transform.localPosition = Vector3.Lerp(initialPos, targetPos, elapsedTime);
            elapsedTime += Time.deltaTime * openSpeed;
            yield return null;
        }

        // Ensure the door reaches the target position exactly
        transform.localPosition = targetPos;
    }
}
