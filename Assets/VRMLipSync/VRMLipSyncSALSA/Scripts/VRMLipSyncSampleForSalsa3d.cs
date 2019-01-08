﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyMinnow.SALSA;

public class VRMLipSyncSampleForSalsa3d : MonoBehaviour
{
	public AudioSource audioSource;
	public Salsa3D salsa3d;
	public GameObject VRMRoot;

	void Update()
	{
		if(audioSource != null && Input.GetKey(KeyCode.Space))
		{
			audioSource.Play();
		}
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(30, 30, 100, 30),"Load VRM"))
        {
            LoadVRMClicked();
        }
		if (GUI.Button(new Rect(150, 30, 100, 30),"Play voice"))
        {
			if (audioSource != null)
			{
	            audioSource.Play();
			}
        }
    }

    void LoadVRMClicked()
    {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        var path = VRM.FileDialogForWindows.FileDialog("open VRM", ".vrm");
#else
        var path = Application.streamingAssetsPath + "/Vita.vrm";
#endif
        if (!string.IsNullOrEmpty(path))
        {
			VRM.VRMImporter.LoadVrmAsync(path, OnLoadedVrm);
        }
    }

	void OnLoadedVrm(GameObject vrm)
	{
		if (VRMRoot != null)
		{
			vrm.transform.SetParent(VRMRoot.transform, false);
		}

		var target = vrm.AddComponent<VRMLipSyncSalsaTarget>();
		target.blendShapeProxy = vrm.GetComponent<VRM.VRMBlendShapeProxy>();
		target.salsa3d = this.salsa3d;
	}
}
