using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLook : MonoBehaviour
{
    public Camera Cam;
    private float xRotation = 0f;

    public float sensitivityX = 30f;
    public float sensitivityY = 30f;

    [SerializeField] private Slider XSlider;
    [SerializeField] private Slider YSlider;

    private float defaultSensitivityX = 30f;
    private float defaultSensitivityY = 30f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        LoadSensitivityValues();
    }

    private void Update()
    {
        ProcessLook(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
    }

    private void LoadSensitivityValues()
    {
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

    private void SaveSensitivityValues()
    {
        PlayerPrefs.SetFloat("SensitivityX", sensitivityX);
        PlayerPrefs.SetFloat("SensitivityY", sensitivityY);
        PlayerPrefs.Save();
    }

    public void SetSensitivityX()
    {
        sensitivityX = XSlider.value;
        SaveSensitivityValues();
    }

    public void SetSensitivityY()
    {
        sensitivityY = YSlider.value;
        SaveSensitivityValues();
    }

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * sensitivityY;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

        Cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * sensitivityX);
    }
}
