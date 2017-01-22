using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour {

    private Renderer renderer;
    private float currentOffset = 0;
    public float scrollSpeed;
    public float switchTime;
    private bool canSwitch = true;

    public Material[] carpetMaterials;

    void Start() {
        renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = "Carpet";
    }

    public void switchFrequency(int index) {
        if (canSwitch) {
            renderer.material = carpetMaterials[index];
            StartCoroutine(switchDelay());
        }
    }

    private IEnumerator switchDelay() {
        canSwitch = false;
        yield return new WaitForSeconds(switchTime);
        canSwitch = true;
        yield return null;
    }

    // Update is called once per frame
    void Update() {
        currentOffset += scrollSpeed * Time.fixedDeltaTime;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(currentOffset, 0));
    }
}
