using UnityEngine;
using System.Collections;

public class Bar : MonoBehaviour 
{
	public GameObject RangeBarMin;
	public GameObject RangeBarMax;
	public GameObject Pointer;
	public float MaxRange = 1f;//0.489
	public float MinRange = -1f;//-0.489
	public float PointerSpeed = 0.1f;
	public float PointerPos = 0f;
	public float DurationTime = 3f;
	public float TempDeltaTime = 1f;


	void Start () 
	{
	
	}
	

	void Update () 
	{
		if(MinRange>1)
			MinRange = 1;
		if(MinRange<-1)
			MinRange = -1;
		if(MaxRange>1)
			MaxRange = 1;
		if(MaxRange<-1)
			MaxRange = -1;

		if(MinRange>-1&&MinRange<0)
			RangeBarMin.transform.localPosition = new Vector3(RangeBarMin.transform.localPosition.x, 0.489f * MinRange,RangeBarMin.transform.localPosition.z);
		else if (MinRange<1&&MinRange>0)
			RangeBarMin.transform.localPosition = new Vector3(RangeBarMin.transform.localPosition.x, -0.489f * MinRange,RangeBarMin.transform.localPosition.z);
		else if(MinRange == 1)
			RangeBarMin.transform.localPosition = new Vector3(RangeBarMin.transform.localPosition.x, 0.489f,RangeBarMin.transform.localPosition.z);
		else if(MinRange == -1)
			RangeBarMin.transform.localPosition = new Vector3(RangeBarMin.transform.localPosition.x, -0.489f,RangeBarMin.transform.localPosition.z);
		else if(MinRange == 0)
			RangeBarMin.transform.localPosition = new Vector3(RangeBarMin.transform.localPosition.x, 0f,RangeBarMin.transform.localPosition.z);

		if(MaxRange>-1&&MinRange<0)
			RangeBarMax.transform.localPosition = new Vector3(RangeBarMax.transform.localPosition.x, 0.489f * MaxRange,RangeBarMax.transform.localPosition.z);
		else if (MaxRange<1&&MinRange>0)
			RangeBarMax.transform.localPosition = new Vector3(RangeBarMax.transform.localPosition.x, -0.489f * MaxRange,RangeBarMax.transform.localPosition.z);
		else if(MaxRange == 1)
			RangeBarMax.transform.localPosition = new Vector3(RangeBarMax.transform.localPosition.x, 0.489f,RangeBarMax.transform.localPosition.z);
		else if(MaxRange == -1)
			RangeBarMax.transform.localPosition = new Vector3(RangeBarMax.transform.localPosition.x, -0.489f,RangeBarMax.transform.localPosition.z);
		else if(MaxRange == 0)
			RangeBarMax.transform.localPosition = new Vector3(RangeBarMax.transform.localPosition.x, 0f,RangeBarMax.transform.localPosition.z);

		if(PointerPos>=0.489||PointerPos<=-0.489)
			PointerSpeed*=-1;

		PointerPos += (PointerSpeed * Time.deltaTime * TempDeltaTime);
		Pointer.transform.localPosition = new Vector3(Pointer.transform.localPosition.x, PointerPos , Pointer.transform.localPosition.z);
		if (Input.GetButton("Fire1"))
			PointerSpeed = 0;
	}
}
