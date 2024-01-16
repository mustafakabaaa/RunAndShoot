using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    // Reference to the camera and initial rotation around the x-axis
    public Camera Cam;
    private float xRotation = 0f;

    // Sensitivity for mouse movement in the x and y directions
    public float sensitivityX = 30f;
    public float sensitivityY = 30f;

    // Sliders to adjust sensitivity in real-time
    [SerializeField] private Slider XSlider;
    [SerializeField] private Slider YSlider;

    // Default sensitivity values
    private float defaultSensitivityX = 30f;
    private float defaultSensitivityY = 30f;

    // Called when the script starts
    private void Start()
    {
        // Lock the cursor and load sensitivity values from PlayerPrefs
        Cursor.lockState = CursorLockMode.Locked;

        // Load sensitivity values from PlayerPrefs or use defaults
        LoadSensitivityValues();
    }

    // Called every frame
    private void Update()
    {
        // Process mouse input for looking around
        ProcessLook(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }

    // Load sensitivity values from PlayerPrefs
    private void LoadSensitivityValues()
    {
        // Check if sensitivity values are saved in PlayerPrefs, otherwise use default values
        if (PlayerPrefs.HasKey("SensitivityX"))
        {
            XSlider.value = PlayerPrefs.GetFloat("SensitivityX");
            SetSensitivityX();
        }
        else
        {
            XSlider.value = defaultSensitivityX;
            SetSensitivityX();
        }

        if (PlayerPrefs.HasKey("SensitivityY"))
        {
            YSlider.value = PlayerPrefs.GetFloat("SensitivityY");
            SetSensitivityY();
        }
        else
        {
            YSlider.value = defaultSensitivityY;
            SetSensitivityY();
        }
    }

    // Save sensitivity values to PlayerPrefs
    private void SaveSensitivityValues()
    {
        PlayerPrefs.SetFloat("SensitivityX", sensitivityX);
        PlayerPrefs.SetFloat("SensitivityY", sensitivityY);
        PlayerPrefs.Save();
    }

    // Set sensitivity in the x-axis and save the value
    public void SetSensitivityX()
    {
        sensitivityX = XSlider.value;
        SaveSensitivityValues();
    }

    // Set sensitivity in the y-axis and save the value
    public void SetSensitivityY()
    {
        sensitivityY = YSlider.value;
        SaveSensitivityValues();
    }

    // Process mouse input for looking around
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Adjust the xRotation based on the mouse input
        xRotation -= (mouseY * Time.deltaTime) * sensitivityY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        // Apply the rotation to the camera
        Cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the entire player object around the y-axis based on the mouse input
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivityX);
    }
}
