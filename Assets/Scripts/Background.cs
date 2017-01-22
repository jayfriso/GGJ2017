using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    private Renderer renderer;
    private float currentOffset = 0;
    public float scrollSpeed;

    void Start() {
        renderer = GetComponent<Renderer>();
        renderer.sortingLayerName = "Background";
    }

	// Update is called once per frame
	void Update () {
        currentOffset += scrollSpeed * Time.fixedDeltaTime;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(currentOffset, 0));
	}
}
