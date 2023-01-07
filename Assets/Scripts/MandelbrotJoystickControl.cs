using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MandelbrotJoystickControl : MonoBehaviour
{
    private Mandelbrot mandelbrot;

    public FloatingJoystick zoomStick;
    public FloatingJoystick moveStick;
    public int zoomSpeed = 20;
    public int moveSpeed = 20;
    
    void Awake()
    {
        mandelbrot = GetComponent<Mandelbrot>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Zoom in or out with joystick
        double zoomSpeedX = (mandelbrot.xMax - mandelbrot.xMin) / zoomSpeed;
        double zoomSpeedY = (mandelbrot.yMax - mandelbrot.yMin) / zoomSpeed;

        mandelbrot.xMin += zoomSpeedX * zoomStick.Vertical;
        mandelbrot.xMax -= zoomSpeedX * zoomStick.Vertical;
        mandelbrot.yMin += zoomSpeedY * zoomStick.Vertical;
        mandelbrot.yMax -= zoomSpeedY * zoomStick.Vertical;
        
        // Move with joystick
        double moveSpeedX = (mandelbrot.xMax - mandelbrot.xMin) / moveSpeed;
        double moveSpeedY = (mandelbrot.yMax - mandelbrot.yMin) / moveSpeed;

        mandelbrot.xMin -= moveSpeedX * moveStick.Horizontal;
        mandelbrot.xMax -= moveSpeedX * moveStick.Horizontal;
        
        mandelbrot.yMin -= moveSpeedY * moveStick.Vertical;
        mandelbrot.yMax -= moveSpeedY * moveStick.Vertical;
        
        
    }
}
