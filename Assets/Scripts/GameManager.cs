using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Slider iterSlider; // reference to the slider component
    public Slider resolutionSlider; // reference to the slider component
    public Dropdown dropdown;
    public Mandelbrot mandelbrot;
    
    public void Start()
    {
        mandelbrot.maxIterations = (int)iterSlider.value;
        mandelbrot.width = (int)resolutionSlider.value;
        mandelbrot.height = (int)resolutionSlider.value;
        
        mandelbrot.colorMode = dropdown.value;
        
        //Adds a listener to slider and invokes a method when the value changes.
        iterSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        resolutionSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        dropdown.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        
        iterSlider.GetComponentInChildren<Text>().text = "Max Iteration: " + iterSlider.value;
        resolutionSlider.GetComponentInChildren<Text>().text = "Resolution: " + resolutionSlider.value;
    }
	
    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        mandelbrot.maxIterations = (int)iterSlider.value;
        mandelbrot.width = (int)resolutionSlider.value;
        mandelbrot.height = (int)resolutionSlider.value;
        mandelbrot.colorMode = dropdown.value;
        iterSlider.GetComponentInChildren<Text>().text = "Max Iteration: " + iterSlider.value;
        resolutionSlider.GetComponentInChildren<Text>().text = "Resolution: " + resolutionSlider.value;
    }
    
    void Update()
    {
        // In case the max iter value was changed from keyboard Q/E
        iterSlider.value = mandelbrot.maxIterations;
    }
}
