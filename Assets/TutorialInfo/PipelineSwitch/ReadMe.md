**Requires Unity 2018.2**
# Scriptable Render Pipeline (SRP) Hot Switching
This folder contains the content needed to easily switch from the Lightweight Render Pipeline (LWRP) to the High Definition Render Pipeline (HDRP). 

For information about the whole project, see our [blog post](link to blog post here).

For information about the SRP and each pipeline, see the following:

[ScriptableRenderPipeline](https://github.com/Unity-Technologies/ScriptableRenderPipeline)

[Lightweight Pipeline Blogpost](https://blogs.unity3d.com/2018/02/21/the-lightweight-render-pipeline-optimizing-real-time-performance/)

[High Definition Pipeline Blogpost](https://blogs.unity3d.com/2018/03/16/the-high-definition-render-pipeline-focused-on-visual-quality/)

## What's in the folder?
The contents of the folder are as follows:
1. PipelineSwitch.cs
    - This file contains the functions needed to switch the pipeline settings, and to draw buttons on a custom editor for easy access.
2. PipelineSettings subfolder
    - This subfolder contains the neccessary Render Pipeline assets, SceneSettings assets, and sample skybox settings to switch between pipelines.
3. Resources subfolder
    - This subfolder contains the scripts to reference the assets in the PipelineSettings subfolder to load in the functions of PipelineSwitch.cs .

## What does it do?
To use a render pipeline in the SRP, you need to load in a Render Pipeline Asset to the Graphics settings. For LWRP and HDRP, there are additional settings that are required for full functionality. 
HDRP requires:
- A High Defintion Render Pipeline Asset in the Graphics settings.
- Colors set to `Linear` rather than `Gamma` in the Player settings.
- A SceneSettings GameObject in the active scene.
- Either a procedural skybox or and HDRI Cubemap in the SceneSettings.

LWRP requires:
- A Lightweight Render Pipeline Asset in the Graphics settings.
- A Skybox material to be set in Lighting settings.

Each function in PipelineSwitch.cs loads the relevant settings assets and changes the relevant settings to ensure that each pipeline will function properly. Asset references can be changed to suit the needs of each individual project, and PipelineSwitch.Draw() can be called on a CustomEditor to draw buttons that will trigger each function.

For this example, the scene lights and SceneSettings GameObjects have been stored in appropriate prefabs for each render pipeline, and the functions simply remove the old prefab and load in the desired prefab when the pipelines are changed. Since LWRP will function with the colors set to `Linear` rather than `Gamma`, that setting is static and doesn't change with buttons in this project.