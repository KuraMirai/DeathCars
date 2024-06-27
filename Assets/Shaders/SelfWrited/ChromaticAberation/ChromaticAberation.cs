using UnityEngine;

[ExecuteInEditMode]
public class ChromaticAberation : MonoBehaviour
{
    public Material Mat;
 
    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Mat);
    }
}
