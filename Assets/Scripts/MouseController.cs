using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MouseController : MonoBehaviour {
    public GameObject testObject;

    public AbilityUI abilities;

	void Start() {
	
	}
	
	void Update() {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 10000.0f)) {
                GameObject gm = Instantiate(abilities.selectedAbility.GetComponent<AbilityKeybind>().prefab, hit.point + abilities.selectedAbility.GetComponent<AbilityKeybind>().prefab.transform.position, Quaternion.identity) as GameObject;
                Debug.Log("You selected the " + hit.point);
            }
        }
    }
}
