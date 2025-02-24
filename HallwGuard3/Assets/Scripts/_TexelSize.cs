using UnityEngine;

public class BlurShaderController : MonoBehaviour
{
    public Material blurMaterial; // Assign this material in the inspector
    public Texture2D textureToBlur;

    void Start()
    {
        // Ensure the material is assigned
        if (blurMaterial != null && textureToBlur != null)
        {
            // Calculate the texel size: (1.0 / texture width, 1.0 / texture height)
            Vector4 texelSize = new Vector4(1.0f / textureToBlur.width, 1.0f / textureToBlur.height, 0.0f, 0.0f);
            
            // Set the _TexelSize property on the shader
            blurMaterial.SetVector("_TexelSize", texelSize);
        }
    }
}
