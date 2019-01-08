using UnityEngine;
using VRM;
using CrazyMinnow.SALSA;

public class VRMLipSyncSalsaTarget : MonoBehaviour
{
	public BlendShapePreset SaySmallBlendShapeKey = BlendShapePreset.I;
	public BlendShapePreset SayMediumBlendShapeKey = BlendShapePreset.E;
	public BlendShapePreset SayLargeBlendShapeKey = BlendShapePreset.O;

	public VRMBlendShapeProxy blendShapeProxy;
	public Salsa3D salsa3d;

	void Start()
	{
		if(salsa3d == null)
		{
			salsa3d = GetComponent<Salsa3D>();
		}
		if(blendShapeProxy == null)
		{
			blendShapeProxy = GetComponent<VRMBlendShapeProxy>();
		}
	}

	void Update()
	{
		if((salsa3d != null) && (blendShapeProxy != null))
		{
			SalsaBlendAmounts blendAmounts = salsa3d.sayAmount;

			// Change the value range before set the BlendShape values.
			float saySmall = blendAmounts.saySmall / 100.0f;
			float sayMedium = blendAmounts.sayMedium / 100.0f;
			float sayLarge = blendAmounts.sayLarge / 100.0f;

			blendShapeProxy.SetValue(SaySmallBlendShapeKey, saySmall);
			blendShapeProxy.SetValue(SayMediumBlendShapeKey, sayMedium);
			blendShapeProxy.SetValue(SayLargeBlendShapeKey, sayLarge);
		}
	}
}
