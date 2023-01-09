using UnityEngine;

public class Mandelbrot : MonoBehaviour
{
    private readonly int _width = Screen.width;
    private readonly int _height = Screen.height;
    
    public float xMin = -2.0f;
    public float xMax = 1.0f;
    public float yMin = -1.5f;
    public float yMax = 1.5f;
    
    private float _prevXMin;
    private float _prevXMax;
    private float _prevYMin;
    private float _prevYMax;
    private bool _valuesChanged;

    public int maxIterations = 128;
    public int colorMode;
    
    public ComputeShader computeShader;
    public RenderTexture renderTexture;

    private void Start()
    {
        if (Screen.width > Screen.height)
        {
            var percent = (float)Screen.width / Screen.height;
            var newMinX = xMin - (xMax - xMin) * (0.5f * (percent - 1));
            var newMaxX = xMax + (xMax - xMin) * (0.5f * (percent - 1));
            xMin = newMinX;
            xMax = newMaxX;
        }
    
        if (Screen.width < Screen.height)
        {
            var percent = (float)Screen.height / Screen.width;
            var newMinY = yMin - (yMax - yMin) * (0.5f * (percent - 1));
            var newMaxY = yMax + (yMax - yMin) * (0.5f * (percent - 1));
            yMin = newMinY;
            yMax = newMaxY;
        }
    }
    
    private void Update()
    {
        // Check if any of the public attributes have changed
        if (!xMin.Equals(_prevXMin) || !xMax.Equals(_prevXMax) || !yMin.Equals(_prevYMin) || !yMax.Equals(_prevYMax))
        {
            _valuesChanged = true;
            _prevXMin = xMin;
            _prevXMax = xMax;
            _prevYMin = yMin;
            _prevYMax = yMax;
        }
        else
        {
            _valuesChanged = false;
        }
    }
    
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (renderTexture == null)
        {
            renderTexture = new RenderTexture(_width, _height, 24);
            renderTexture.enableRandomWrite = true;
            renderTexture.Create();
        }
        
        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.SetFloat("width", _width);
        computeShader.SetFloat("height", _height);
        computeShader.SetFloat("xMin", xMin);
        computeShader.SetFloat("xMax", xMax);
        computeShader.SetFloat("yMin", yMin);
        computeShader.SetFloat("yMax", yMax);
        computeShader.SetFloat("timeSinceLevelLoad", Time.timeSinceLevelLoad);
        computeShader.SetInt("maxIterations", maxIterations);
        computeShader.SetInt("colorMode", colorMode);
        computeShader.SetBool("drawCircle", _valuesChanged);
        
        computeShader.Dispatch(0, renderTexture.width/8, renderTexture.height/8,1);
        
        Graphics.Blit(renderTexture, dest);
    }
}