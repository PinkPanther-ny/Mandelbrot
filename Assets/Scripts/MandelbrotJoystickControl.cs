using UnityEngine;

public class MandelbrotJoystickControl : MonoBehaviour
{
    private Mandelbrot _mandelbrot;

    public FloatingJoystick zoomStick;
    public FloatingJoystick moveStick;
    public float zoomSpeed = 0.3f;
    public float moveSpeed = 0.3f;
    public int zoomReverseMultiplier = 1;
    public int moveReverseMultiplier = 1;
    
    void Awake()
    {
        _mandelbrot = GetComponent<Mandelbrot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoomStick.Vertical > 0 && _mandelbrot.xMax - _mandelbrot.xMin > 1e-4 || (zoomStick.Vertical < 0 && _mandelbrot.xMax - _mandelbrot.xMin < 5e3))
        {
            // Zoom in or out with joystick
            float zoomSpeedX = (_mandelbrot.xMax - _mandelbrot.xMin) / (100.0f / zoomSpeed);
            float zoomSpeedY = (_mandelbrot.yMax - _mandelbrot.yMin) / (100.0f / zoomSpeed);

            _mandelbrot.xMin += zoomReverseMultiplier * zoomSpeedX * zoomStick.Vertical;
            _mandelbrot.xMax -= zoomReverseMultiplier * zoomSpeedX * zoomStick.Vertical;
            _mandelbrot.yMin += zoomReverseMultiplier * zoomSpeedY * zoomStick.Vertical;
            _mandelbrot.yMax -= zoomReverseMultiplier * zoomSpeedY * zoomStick.Vertical;
        }
        
        // Move with joystick
        float moveSpeedX = (_mandelbrot.xMax - _mandelbrot.xMin) / (100.0f / moveSpeed);
        float moveSpeedY = (_mandelbrot.yMax - _mandelbrot.yMin) / (100.0f / moveSpeed);

        _mandelbrot.xMin -= moveReverseMultiplier * moveSpeedX * moveStick.Horizontal;
        _mandelbrot.xMax -= moveReverseMultiplier * moveSpeedX * moveStick.Horizontal;
        
        _mandelbrot.yMin -= moveReverseMultiplier * moveSpeedY * moveStick.Vertical;
        _mandelbrot.yMax -= moveReverseMultiplier * moveSpeedY * moveStick.Vertical;
        
        
    }
}
