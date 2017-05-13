using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
	public Vector2 XY_Max;
	public Vector2 XY_Min;

	public float Xdistance=1f;
	public float Ydistance=1f;
	public float xSmooth = 8f;
	public float ySmooth = 8f;

	public Transform heropos;

	void Start () {
		heropos = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate()
	{
		float fnewX = transform.position.x;
		float fnewY = transform.position.y;
		if(IsLargX())
			fnewX = Mathf.Lerp(transform.position.x, heropos.position.x,xSmooth * Time.deltaTime);
		if(IsLargY())
			fnewY = Mathf.Lerp(transform.position.y, heropos.position.y,ySmooth * Time.deltaTime);

		fnewX = Mathf.Clamp (fnewX, XY_Min.x, XY_Max.x);
		fnewY = Mathf.Clamp (fnewY, XY_Min.y, XY_Max.y);

		transform.position = new Vector3 (fnewX,
			fnewY,
			transform.position.z);	
	}

	private bool IsLargX()
	{
		return(Mathf.Abs (heropos.position.x - transform.position.x) > Xdistance);
	}
	private bool IsLargY()
	{
		return(Mathf.Abs (heropos.position.y - transform.position.y) > Xdistance);
	}
}
