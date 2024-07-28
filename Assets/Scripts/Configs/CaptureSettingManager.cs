using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaptureSettingManager : MonoBehaviour
{
    public GameObject CaptureDisplay;
    private Material WindowMaterial;
    private TMP_Dropdown Dropdown;
    private Toggle Toggle;
    void Start()
    {
        WindowMaterial = CaptureDisplay.GetComponent<Renderer>().material;
        Dropdown = GetComponent<TMP_Dropdown>();
        Toggle = GetComponent<Toggle>();
        switch (gameObject.name)
        {
            case "CPModeDropdown":
                GetCPMode();
                break;
            case "CPDesktop":
                GetCPDesktop();
                break;
            case "CPFPSDropdown":
                GetCPFPS();
                break;
            case "CP1P":
                GetCP1P();
                break;
        }
    }
    public void GetCPMode()
    {
        if (JsonConfig.HasKey("CaptureMode"))
            Dropdown.value = JsonConfig.GetInt("CaptureMode");
        SetCPMode();
    }
    public void GetCPDesktop()
    {
        if (JsonConfig.HasKey("CaptureDesktop"))
            Toggle.isOn = JsonConfig.GetBoolean("CaptureDesktop");
        SetCPDesktop();
    }
    public void GetCPFPS()
    {
        if (JsonConfig.HasKey("CaptureFPS"))
            Dropdown.value = JsonConfig.GetInt("CaptureFPS");
        SetCPFPS();

    }
    public void GetCP1P()
    {
        if (JsonConfig.HasKey("Capture1P"))
            Toggle.isOn = JsonConfig.GetBoolean("Capture1P");
        SetCP1P();
    }

    public void SetCPMode()
    {
        JsonConfig.SetInt("CaptureMode", Dropdown.value);
    }

    public void SetCPDesktop()
    {
        JsonConfig.SetBoolean("CaptureDesktop", Toggle.isOn);
    }

    public void SetCPFPS()
    {
        JsonConfig.SetInt("CaptureFPS", Dropdown.value);
    }

    public void SetCP1P()
    {
        WindowMaterial.SetTextureScale("_MainTex", new Vector2(Toggle.isOn ? 1f : 0.5f, -1));
        JsonConfig.SetBoolean("Capture1P", Toggle.isOn);
    }
}
