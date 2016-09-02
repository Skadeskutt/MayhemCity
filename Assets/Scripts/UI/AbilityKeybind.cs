using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AbilityKeybind : MonoBehaviour {
    public KeyCode keybind = KeyCode.Alpha0;

    public GameObject prefab;

    private Button button;
    private Text keyDisplay;

    void Start() {
        button = GetComponent<Button>();
        keyDisplay = transform.GetComponentInChildren<Text>();
    }
	
	void Update() {
        if(keyDisplay.text != (keybind - 48).ToString())
            keyDisplay.text = (keybind - 48).ToString();
        if(Input.GetKeyDown(keybind))
            button.onClick.Invoke();
    }
}
