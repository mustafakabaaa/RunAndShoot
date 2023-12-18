using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    // Ýnteraksiyon olayýný tanýmlayýn
    public UnityEvent onInteract;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public abstract class Interactable : MonoBehaviour
{
    public delegate void InteractAction();
    public static event InteractAction OnInteract;

    public bool useEvents;

    [SerializeField]
    public string promptMessage;

    public void BaseInteract()
    {
        if (useEvents)
        {
            // Olay Yöneticisi'ni kullanarak etkileþim olayýný çaðýrýn
            EventManager.instance.onInteract.Invoke();
        }

        if (OnInteract != null)
        {
            // Delegasyonu kullanarak etkileþim olayýný çaðýrýn
            OnInteract();
        }

        Interact();
    }

    public virtual string OnLook()
    {
        return promptMessage;
    }

    protected virtual void Interact()
    {
        // Etkileþim mantýðýnýz
    }
}
