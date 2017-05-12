using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour {
	
	public float MaxForce = 300f;//最大force
	public float MaxSpeed = 5f;//角色最大速度
	public float JumpForce = 400;
	[HideInInspector]
	public bool bFaceRight = true;//角色朝向
	[HideInInspector]
	public bool bGrounded = false;//判断角色是否在地面
	[HideInInspector]
	public bool jump = false;

	private Rigidbody2D heroBody;
	private Transform mGroundCheck;

	private void Awake()
	{
		mGroundCheck = transform.Find("GroundCheck");
	}

	// Use this for initialization
	void Start () {
		heroBody = gameObject.GetComponent<Rigidbody2D> ();
		//heroBody.mass = 2;
	}

	// Update is called once per frame
	void Update () {
		bGrounded = Physics2D.Linecast (transform.position,
			mGroundCheck.position,
			1 << LayerMask.NameToLayer ("ground"));
		Debug.DrawLine (transform.position,
			mGroundCheck.position,Color.red,1f);
		if (Input.GetButtonDown ("Jump")&& bGrounded ) 
		{
			jump = true;
		}
	}

	private void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");//水平

		//左右/限制最大速度
		if (h * heroBody.velocity.x < MaxSpeed)
			heroBody.AddForce (Vector2.right * h * MaxForce);
		if (Mathf.Abs(heroBody.velocity.x) > MaxSpeed)
			heroBody.velocity = new Vector2 (Mathf.Sign(heroBody.velocity.x) * MaxSpeed, heroBody.velocity.y); 
		//
		if (h > 0 && !bFaceRight)
			flip ();
		else if (h < 0 && bFaceRight)
			flip ();

		if (jump) 
		{
			heroBody.AddForce (new Vector2 (0, JumpForce));
			jump = false;
		}

		
			
	}

	void flip()
	{
		bFaceRight = !bFaceRight;

		Vector3 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}
}
