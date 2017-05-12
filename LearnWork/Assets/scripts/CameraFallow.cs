using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFallow : MonoBehaviour {

	// Use this for initialization
	public Vector2 XY_Max;
	public Vector2 XY_Min;
	public Transform heropos;
	public float Xdistance=1;
	public float Ydistance=2;
	void Start () {
		heropos = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		float fnewX = heropos.position.x;
		float fnewY = heropos.position.y;
		if(IsLargX())
			fnewX = Mathf.Clamp(heropos.position.x,XY_Min.x,XY_Max.x);
		if(IsLargY())
			fnewY = Mathf.Clamp(heropos.position.y,XY_Min.y,XY_Max.y);

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
