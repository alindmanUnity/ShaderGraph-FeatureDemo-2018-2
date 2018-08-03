using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;
using UnityEngine.Experimental;
using UnityEngine.Experimental.Rendering;

public static class PipelineSwitch 
{
	static string resourcePath = "Resources";

	public static void SwitchToLightweight () {
		PipelineSwitchResources resources = Resources.Load<PipelineSwitchResources>(resourcePath);
		//resources.LightWeightSwitch();

		GraphicsSettings.renderPipelineAsset = resources.lwAsset;
		RenderSettings.skybox = resources.lwSkybox;

		if(resources.sceneSettings == null){
			resources.sceneSettings = UnityEngine.GameObject.Instantiate(resources.LWPrefab, Vector3.zero, Quaternion.identity);
		}
		else
		{
			UnityEngine.GameObject.DestroyImmediate(resources.sceneSettings);
			resources.sceneSettings = UnityEngine.GameObject.Instantiate(resources.LWPrefab, Vector3.zero, Quaternion.identity);
		}
	}

	public static void SwitchToHighDefinition () {
		PipelineSwitchResources resources = Resources.Load<PipelineSwitchResources>(resourcePath);
		GraphicsSettings.renderPipelineAsset = resources.hdAsset;
		
		if(resources.sceneSettings == null){
			resources.sceneSettings = UnityEngine.GameObject.Instantiate(resources.HDPrefab, Vector3.zero, Quaternion.identity);
		}
		else
		{
			UnityEngine.GameObject.DestroyImmediate(resources.sceneSettings);
			resources.sceneSettings = UnityEngine.GameObject.Instantiate(resources.HDPrefab, Vector3.zero, Quaternion.identity);
		}
	}

	public static void Draw()
	{
		if (GUILayout.Button("To Light Weight Render Pipeline")){
            SwitchToLightweight();
        }
        if (GUILayout.Button("To High Definition Render Pipeline")){
            SwitchToHighDefinition();
        }	
	}
}
