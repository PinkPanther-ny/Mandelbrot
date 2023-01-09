using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Slider iterSlider; // reference to the slider component
    public Dropdown dropdown;
    public Button resetButton;
    public Button captureButton;
    public Text captureText;
    public Mandelbrot mandelbrot;
    
    public void Start()
    {
        mandelbrot.maxIterations = (int)iterSlider.value;
        
        mandelbrot.colorMode = dropdown.value;
        
        //Adds a listener to slider and invokes a method when the value changes.
        iterSlider.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        dropdown.onValueChanged.AddListener (delegate {ValueChangeCheck ();});
        resetButton.onClick.AddListener (Reset);
        captureButton.onClick.AddListener (ImageCapture);
        
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

    public void ImageCapture()
    {
        if( !Permission.HasUserAuthorizedPermission( Permission.ExternalStorageWrite ) )
        {
            Permission.RequestUserPermission( Permission.ExternalStorageWrite );
        }
        else
        {
            mandelbrot.SaveRenderTextureToImage();
            captureText.gameObject.SetActive(true); // display the text
            captureText.color = Color.red;
            StartCoroutine(FadeOutText(1f)); // start the fade out coroutine with a duration of 1 second
        }

    }
    
    IEnumerator<float?> FadeOutText(float duration)
    {
        float elapsedTime = 0;
        Color originalColor = captureText.color;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            captureText.color = Color.Lerp(originalColor, Color.clear, elapsedTime / duration);
            yield return null;
        }
    }
    
    private void Update()
    {
        // In case the max iter value was changed from keyboard Q/E
        iterSlider.value = mandelbrot.maxIterations;
    }
}
