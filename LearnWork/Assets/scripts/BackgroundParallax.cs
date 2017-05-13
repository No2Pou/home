using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour {
	public Transform[] backgrounds;
	public float parallaxScale;
	public float parallaxReductionFactor;
	public float smoothing;

	private Transform cam;
	private Vector3 previousCampos;//摄像机上一帧的位置

	void Awake()
	{
		cam = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCampos = cam.position;
		
	}
	
	// Update is called once per frame
	void Update () {

		float parallax = (previousCampos.x - cam.position.x) * parallaxScale;

		for (int i = 0; i < backgrounds.Length; i++) 
		{
			float backgroundTargetPosX = backgrounds [i].position.x + parallax * (i * parallaxReductionFactor + 1);

			Vector2 backgroundTargetPos = new Vector2 (backgroundTargetPosX, backgrounds [i].position.y);
		
			backgrounds [i].position = Vector2.Lerp (backgrounds [i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCampos = cam.position;
	}
}
