using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessCam : MonoBehaviour
{

    [SerializeField] private Material material;

    private void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }


}
