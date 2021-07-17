using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public RenderPipelineAsset VRPipeline;
    public RenderPipelineAsset ARPipeline;

    public void VRMode()
    {
        GraphicsSettings.renderPipelineAsset = VRPipeline;
        SceneManager.LoadScene("BasicVRScene");
    }

    public void ARMode()
    {
        GraphicsSettings.renderPipelineAsset = ARPipeline;
        SceneManager.LoadScene("Basic-AR");
    }
}
