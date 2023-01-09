using UnityEngine;

public class MandelbrotKeyboardControl : MonoBehaviour
{
    private Mandelbrot _mandelbrot;
    public int zoomSpeed = 20;
    public int moveSpeed = 20;
    public int addIter = 10;

    private void Awake()
    {
        _mandelbrot = GetComponent<Mandelbrot>();
    }

    private void Update()
    {
        // Zoom in or out with the mouse scroll wheel or the "Q" and "E" keys
        float zoomSpeedX = (_mandelbrot.xMax - _mandelbrot.xMin) / zoomSpeed;
        float zoomSpeedY = (_mandelbrot.yMax - _mandelbrot.yMin) / zoomSpeed;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            _mandelbrot.xMin += zoomSpeedX;
            _mandelbrot.xMax -= zoomSpeedX;
            _mandelbrot.yMin += zoomSpeedY;
            _mandelbrot.yMax -= zoomSpeedY;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            _mandelbrot.xMin -= zoomSpeedX;
            _mandelbrot.xMax += zoomSpeedX;
            _mandelbrot.yMin -= zoomSpeedY;
            _mandelbrot.yMax += zoomSpeedY;
        }

        // Calculate more iteration
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _mandelbrot.maxIterations += addIter;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_mandelbrot.maxIterations - addIter <= 2)
            {
                _mandelbrot.maxIterations = 2;
            }
            else
            {
                _mandelbrot.maxIterations -= addIter;
            }
        }

        // Move the view with the "W", "A", "S", and "D" keys
        float moveSpeedX = (_mandelbrot.xMax - _mandelbrot.xMin) / moveSpeed;
        float moveSpeedY = (_mandelbrot.yMax - _mandelbrot.yMin) / moveSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            _mandelbrot.yMin -= moveSpeedY;
            _mandelbrot.yMax -= moveSpeedY;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _mandelbrot.xMin += moveSpeedX;
            _mandelbrot.xMax += moveSpeedX;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _mandelbrot.yMin += moveSpeedY;
            _mandelbrot.yMax += moveSpeedY;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _mandelbrot.xMin -= moveSpeedX;
            _mandelbrot.xMax -= moveSpeedX;
        }
    }
}