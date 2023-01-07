using UnityEngine;
using System.Collections;

public class Mandelbrot : MonoBehaviour
{
    public int width = 720;
    public int height = 720;
    public double xMin = -2.0;
    public double xMax = 1.0;
    public double yMin = -1.5;
    public double yMax = 1.5;
    public int maxIterations = 128;
    public int colorMode = 0;
    void Update()
    {
        Texture2D texture = new Texture2D(width, height);
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                double a = xMin + (xMax - xMin) * x / width;
                double b = yMin + (yMax - yMin) * y / height;
                double real = a;
                double imag = b;
        
                int value = 0;
                for (int i = 0; i < maxIterations; i++)
                {
                    double r2 = real * real;
                    double i2 = imag * imag;
                    imag = 2 * real * imag + b;
                    real = r2 - i2 + a;
                    if (real * real + imag * imag > 4)
                    {
                        value = i;
                        break;
                    }
                }

                float hue, saturation, brightness;
                switch (colorMode)
                {
                    case 1:
                        hue = (float)value / maxIterations;
                        brightness = 1.0f;
                        saturation = Mathf.Abs(Mathf.Sin((float) value / maxIterations * Mathf.PI * 2.0f)) * 5.0f;
                        break;

                    case 2:
                        hue = (float)Mathf.Pow(((float)value / maxIterations) * 360, 1.5f) % 360;
                        saturation = 1.0f;
                        brightness = 1.0f;
                        break;

                    default:
                        hue = (float)value / (maxIterations) + 0.6f + 0.04f * Mathf.Sin(0.7f * Time.timeSinceLevelLoad);
                        brightness = 0.9f + 0.08f * Mathf.Sin(0.6f * Time.timeSinceLevelLoad);
                        saturation = 0.92f + 0.08f * Mathf.Sin(0.3f * Time.timeSinceLevelLoad);
                        break;
                }
                
                Color color = Color.HSVToRGB(hue, saturation, brightness, true);
                texture.SetPixel(x, y, color);
                
            }
        }
        


        texture.Apply();
    }
}