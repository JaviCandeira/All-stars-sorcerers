using System; 
using System.Collections; 
using System.Collections.Generic; 
using TMPro; 
using UnityEngine; 
 
public class TimeScript : MonoBehaviour 
{ 
    [SerializeField] private float timeMult; 
    [SerializeField] private float startHr; 
    [SerializeField] private TextMeshProUGUI timeText; 
     
    [SerializeField] private Light sun; 
    [SerializeField] private float sunriseHr; 
    [SerializeField] private float sunsetHr; 
     
    [SerializeField] private Color dayLight; 
    [SerializeField] private Color nightLight; 
 
    [SerializeField] private AnimationCurve lightCurve; 
    [SerializeField] private float maxSunIntensity; 
 
    [SerializeField] private Light moon; 
    [SerializeField] private float maxMoonIntensity; 
     
    private TimeSpan sunrise; 
    private TimeSpan sunset; 
 
    private DateTime currentTime; 
    // Start is called before the first frame update 
    void Start() 
    { 
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHr); 
        sunrise = TimeSpan.FromHours(sunriseHr); 
        sunset = TimeSpan.FromHours(sunsetHr); 
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        UpdateTimeOfDay(); 
        RotateSunMoon(); 
        UpdateLightSettings(); 
    } 
 
    void UpdateTimeOfDay() 
    { 
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMult); 
 
        if (timeText != null) 
        { 
            timeText.text = currentTime.ToString("HH:mm"); 
        } 
    } 
 
    private void RotateSunMoon() 
    { 
        float sunRotation;
        float moonRotation; 
        if (currentTime.TimeOfDay > sunrise && currentTime.TimeOfDay < sunset) 
        { 
            TimeSpan sunriseToSunset = CalculateTimeDiff(sunrise, sunset); 
            TimeSpan timeSinceSunrise = CalculateTimeDiff(sunrise, currentTime.TimeOfDay); 
 
            double percentage = timeSinceSunrise.TotalMinutes / sunriseToSunset.TotalMinutes; 
 
            sunRotation = Mathf.Lerp(0, 180, (float) percentage);
            moonRotation = Mathf.Lerp(-180, 0, (float) percentage);
        } 
        else 
        { 
            TimeSpan sunsetToSunrise = CalculateTimeDiff(sunset, sunrise); 
            TimeSpan timeSinceSunset = CalculateTimeDiff(sunset, currentTime.TimeOfDay); 
 
            double percentage = timeSinceSunset.TotalMinutes / sunsetToSunrise.TotalMinutes; 
 
            sunRotation = Mathf.Lerp(180, 360, (float) percentage);
            moonRotation = Mathf.Lerp(-360, -180, (float) percentage);
        } 
         
        sun.transform.rotation = Quaternion.AngleAxis(sunRotation,Vector3.right); 
        moon.transform.rotation = Quaternion.AngleAxis(moonRotation,Vector3.right);
    }
    private TimeSpan CalculateTimeDiff(TimeSpan from, TimeSpan to) 
    { 
        TimeSpan diff = to - from; 
 
        if (diff.TotalSeconds < 0) 
        { 
            diff += TimeSpan.FromHours(24); 
        } 
 
        return diff; 
    } 
 
    private void UpdateLightSettings() 
    { 
        float lightDot = Vector3.Dot(sun.transform.forward, Vector3.down); 
        sun.intensity = Mathf.Lerp(0, maxSunIntensity, lightCurve.Evaluate(lightDot)); 
        moon.intensity = Mathf.Lerp(0, maxMoonIntensity, lightCurve.Evaluate(lightDot)); 
        RenderSettings.ambientLight = Color.Lerp(nightLight, dayLight, lightCurve.Evaluate(lightDot)); 
    } 
} 
