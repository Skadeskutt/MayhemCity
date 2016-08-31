using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class AbilityUI : MonoBehaviour {
    public Color selectedColor = Color.yellow;
    public Color readyColor = Color.green;
    public Color inactiveColor = Color.gray;

    public List<GameObject> abilityButtons;
    public GameObject selectedAbility;

    public KeyCode[] keys = { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0 };

    void Awake() {
        abilityButtons.Clear();
        for(int i = 0; i < transform.childCount; i++) {
            GameObject gm = transform.GetChild(i).gameObject;
            gm.GetComponent<Button>().onClick.AddListener(() => {
                setActive(gm);
            });
            abilityButtons.Add(gm);
        }
        selectedAbility = abilityButtons[Random.Range(0, abilityButtons.Count)];
    }
	
	void Update() {
	    for(int index = 0; index < abilityButtons.Count; index++) {
            GameObject gm = abilityButtons[index];
            Image i = gm.GetComponent<Image>();

            AbilityKeybind ak = gm.GetComponent<AbilityKeybind>();
            ak.keybind = keys[index];

            float startPos = abilityButtons.Count % 2 == 0 ? (abilityButtons.Count / 2) * 100f : (abilityButtons.Count / 2) * 100f - 50f;
            Vector3 pos = new Vector3(-50f, startPos - (100f * index), 0f);
            if(gm.transform.localPosition != pos)
                gm.transform.localPosition = pos;

            if(gm == selectedAbility) {
                if(i.color != selectedColor)
                    i.color = selectedColor;
            } else {
                if(i.color != readyColor)
                    i.color = readyColor;
            }
        }
	}

    public void setActive(GameObject gm) {
        selectedAbility = gm;
    }
}
