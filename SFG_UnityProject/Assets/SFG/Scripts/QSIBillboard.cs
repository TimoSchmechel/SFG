//Marsfield RTS Framework
//July 2014 revision
//Matt Cabanag

using UnityEngine;
using System.Collections;

public class QSIBillboard : MonoBehaviour 
{
	public bool yRotMode = false;

	private Transform qacTransform;
	
	void Awake()
	{
		qacTransform = transform;
		//qacTransform.LookAt(billboardFocus);
		qacTransform.rotation = Camera.main.transform.rotation;
	}
	
	// Use this for initialization
	void Start () 
	{
		qacTransform = transform;
		//qacTransform.LookAt(billboardFocus);
		qacTransform.rotation = Camera.main.transform.rotation;
		DoBillboard();
	}
	
	// Update is called once per frame
	void Update () 
	{
		DoBillboard();
	}

	void DoBillboard()
	{
		if(!yRotMode)
		{
			//qacTransform.LookAt(billboardFocus);
			qacTransform.rotation = Camera.main.transform.rotation;
		}
		else
		{
			Quaternion camRot = Camera.main.transform.rotation;
			
			transform.rotation = new Quaternion(0,-camRot.y,0,camRot.w);
		}
	}

	public static GameObject FindClosestSubject(GameObject [] candidateList, Vector3 refPoint)
	{
		GameObject result = null;

		float closest = 100000;

		foreach(GameObject o in candidateList)
		{
			float distance = Vector3.Distance(o.transform.position, refPoint);
			
			if(distance < closest)
			{	closest = distance;
				result = o;
			}
		}

		return result;
	}
}
