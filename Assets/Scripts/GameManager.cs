using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider iterSlider; // reference to the slider component
    public Dropdown dropdown;
    public Button resetButton;
    public Mandelbrot mandelbrot;
    
    public void Start()
    {
        mandelbrot.maxIterations = (int)iterSlider.value;
        
        mandelbrot.colorMode = dropdown.value;
        
        //Adds a listener to slider and invokes a method when the value changes.
        iterSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        dropdown.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        resetButton.onClick.AddListener (Reset);
        
        iterSlider.GetComponentInChildren<Text>().text = "Max Iteration: " + iterSlider.value;
    }
	
    // Invoked when the value of the slider changes.
    public void ValueChangeCheck()
    {
        mandelbrot.maxIterations = (int)iterSlider.value;
        mandelbrot.colorMode = dropdown.value;
        iterSlider.GetComponentInChildren<Text>().text = "Max Iteration: " + iterSlider.value;
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void Update()
    {
        // In case the max iter value was changed from keyboard Q/E
        iterSlider.value = mandelbrot.maxIterations;
    }
}
