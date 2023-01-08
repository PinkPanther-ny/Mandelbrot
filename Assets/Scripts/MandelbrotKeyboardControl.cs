using UnityEngine;
using System.Collections;

public class MandelbrotKeyboardControl : MonoBehaviour
{
    private Mandelbrot mandelbrot;
    public int zoomSpeed = 20;
    public int moveSpeed = 20;
    public int addIter = 10;

    void Awake()
    {
        mandelbrot = GetComponent<Mandelbrot>();
    }

    void Update()
    {
        // Zoom in or out with the mouse scroll wheel or the "Q" and "E" keys
        float zoomSpeedX = (mandelbrot.xMax - mandelbrot.xMin) / zoomSpeed;
        float zoomSpeedY = (mandelbrot.yMax - mandelbrot.yMin) / zoomSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mandelbrot.xMin += zoomSpeedX;
            mandelbrot.xMax -= zoomSpeedX;
            mandelbrot.yMin += zoomSpeedY;
            mandelbrot.yMax -= zoomSpeedY;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mandelbrot.xMin -= zoomSpeedX;
            mandelbrot.xMax += zoomSpeedX;
            mandelbrot.yMin -= zoomSpeedY;
            mandelbrot.yMax += zoomSpeedY;
        }

        // Calculate more iteration
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mandelbrot.maxIterations += addIter;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (mandelbrot.maxIterations - addIter <= 2)
            {
                mandelbrot.maxIterations = 2;
            }
            else
            {
                mandelbrot.maxIterations -= addIter;
            }
        }

        // Move the view with the "W", "A", "S", and "D" keys
        float moveSpeedX = (mandelbrot.xMax - mandelbrot.xMin) / moveSpeed;
        float moveSpeedY = (mandelbrot.yMax - mandelbrot.yMin) / moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            mandelbrot.yMin -= moveSpeedY;
            mandelbrot.yMax -= moveSpeedY;
        }

        if (Input.GetKey(KeyCode.A))
        {
            mandelbrot.xMin += moveSpeedX;
            mandelbrot.xMax += moveSpeedX;
        }

        if (Input.GetKey(KeyCode.S))
        {
            mandelbrot.yMin += moveSpeedY;
            mandelbrot.yMax += moveSpeedY;
        }

        if (Input.GetKey(KeyCode.D))
        {
            mandelbrot.xMin -= moveSpeedX;
            mandelbrot.xMax -= moveSpeedX;
        }
    }
}