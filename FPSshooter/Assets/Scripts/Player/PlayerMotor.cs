using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float walkSpeed = 4f;
    public float speed = 5f;
    public float runSpeed = 7f;
    public float jumpHeight = 3f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public Transform playerGunBarrel;

    private AudioSource footstepsAudioSource;
    private float originalPitch = 1.3f;

    [Header("SOUND CONTROL")]
    public AudioSource jumpSound;
    public GameObject footstepSound;
    public float walkSpeedSound = 1.3f;
    public float runSpeedSound = 1.8f;

    private bool isSprinting = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        footstepsAudioSource = footstepSound.GetComponent<AudioSource>();
        originalPitch = footstepsAudioSource.pitch;
        footstepSound.SetActive(false);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded)
        {
            // Karakter yere basýlýyken koþma iþlemini kontrol et
            isSprinting = Input.GetKey(KeyCode.LeftShift);
        }
        
      
    }

    public void ProcessMove(Vector2 input)
    {
        float currentSpeed = isSprinting ? runSpeed : walkSpeed;

        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        // Adým sesleri
        if (isGrounded && (Mathf.Abs(input.x) > 0.1f || Mathf.Abs(input.y) > 0.1f))
        {
            footstepSound.SetActive(true);

            // Hýzlandýrma için pitch'i güncelle
            float speedFactor = isSprinting ? runSpeedSound : walkSpeedSound;
            footstepsAudioSource.pitch = speedFactor;
        }
        else
        {
            footstepSound.SetActive(false);
        }
    }

    public void JumpFNC()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);

            if (jumpSound != null)
            {
                jumpSound.Play();
            }
        }
    }
}
