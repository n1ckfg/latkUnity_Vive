using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushPreview : MonoBehaviour {

    public LightningArtist latk;
    //public Transform target;

    private Renderer ren;
    private Shader shader1, shader2;
    private LightningArtist.BrushMode lastBrushMode;

    private void Awake() {
        ren = GetComponent<Renderer>();
        shader1 = Shader.Find("Unlit/Color");
        shader2 = Shader.Find("Standard");
    }

	private void Update() {
        if (latk.brushMode != lastBrushMode) {
            if (latk.brushMode == LightningArtist.BrushMode.ADD) {
                ren.material.shader = shader1;
            } else {
                ren.material.shader = shader2;
            }
            lastBrushMode = latk.brushMode;
        }
        ren.sharedMaterial.SetColor("_Color", latk.mainColor);
        transform.localScale = Vector3.one * latk.brushSize;
        if (latk.useCollisions) {
            /*
            RaycastHit hit;
            Ray ray;
            ray = new Ray(target.position, target.forward);
            if (Physics.Raycast(ray, out hit)) {
                transform.position = hit.point;
            }
            */
            if (latk.thisHit != Vector3.zero) {
                transform.position = latk.thisHit;
            } else {
                transform.localPosition = Vector3.zero;
            }
        } else {
            transform.localPosition = Vector3.zero;
        }
	}

}
