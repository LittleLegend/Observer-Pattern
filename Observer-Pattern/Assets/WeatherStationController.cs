﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherStationController : MonoBehaviour {

 
    public float inputDelay;
    public int minTemp;
    public int maxTemp;
    public int minHumid;
    public int maxHumid;
    public WeatherData weatherData = new WeatherData(0, 0);

    [Range(0, 10)] public float PenisLength;
     public float Something;

    void Start () {

        setWeatherData();
        StartCoroutine(handleInput());
        

    }
	
	
    public void setWeatherData()
    {
        weatherData.temperature = minTemp + (maxTemp - minTemp) / 2;
        weatherData.humidity = minHumid +  (maxHumid - minHumid) / 2;
        weatherData.maxHumid = maxHumid;
        weatherData.minHumid = minHumid;
        weatherData.maxTemp = maxTemp;
        weatherData.minTemp = minTemp;
       

    }

    public IEnumerator handleInput()
    {

        while (true)
        {
            if (Input.anyKey)
            {
                while (Input.anyKey)
                {
                    if (Input.GetKey(KeyCode.UpArrow)&& weatherData.temperature < maxTemp)
                    {
                        weatherData.temperature += 1;
                        weatherData.weatherChanged();
                    }

                    if (Input.GetKey(KeyCode.DownArrow) && weatherData.temperature > minTemp)
                    {
                        weatherData.temperature -= 1;
                        weatherData.weatherChanged();
                    }

                    if (Input.GetKey(KeyCode.LeftArrow) && weatherData.humidity > minHumid)
                    {
                        weatherData.humidity -= 1;
                        weatherData.weatherChanged();
                    }

                    if (Input.GetKey(KeyCode.RightArrow) && weatherData.humidity < maxHumid)
                    {
                        weatherData.humidity += 1;
                        weatherData.weatherChanged();
                    }

                    yield return new WaitForSeconds(inputDelay);
                }

            }
            weatherData.weatherChanged();
            yield return true;
        }

    }


}
