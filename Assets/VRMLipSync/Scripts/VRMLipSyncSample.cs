using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMLipSyncSample : MonoBehaviour
{
	public AudioSource audioSource;
	public OVRLipSyncContext lipSyncContext;
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
        if (!string.IsNullOrEmpty(path))
        {
			VRM.VRMImporter.LoadVrmAsync(path, OnLoadedVrm);
        }
#endif
    }

	void OnLoadedVrm(GameObject vrm)
	{
		if (VRMRoot != null)
		{
			vrm.transform.SetParent(VRMRoot.transform, false);
		}

		var morphTarget = vrm.AddComponent<VRMLipSyncMorphTarget>();
		morphTarget.blendShapeProxy = vrm.GetComponent<VRM.VRMBlendShapeProxy>();
		morphTarget.lipsyncContext = lipSyncContext;
	}
}
