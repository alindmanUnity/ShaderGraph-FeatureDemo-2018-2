using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEngine.Experimental;
using UnityEngine.Experimental.Rendering;

[ExecuteInEditMode]
[CreateAssetMenu(fileName = "Resources", menuName = "Pipeline Resources")]
public class PipelineSwitchResources : ScriptableObject 
{
	public RenderPipelineAsset lwAsset;
	public RenderPipelineAsset hdAsset;
	public Material lwSkybox;
	public GameObject LWPrefab;
	public GameObject HDPrefab;
	private GameObject m_SceneSettings;
	public GameObject sceneSettings
	{
		get
		{
			if(m_SceneSettings == null)
				m_SceneSettings = GameObject.FindObjectOfType<SceneSettings>().gameObject;
			return m_SceneSettings;
		}
		set
		{
			m_SceneSettings = value;
		}
	}
}