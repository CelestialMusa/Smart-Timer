using System;
using Windows.UI.Xaml.Controls;

public class Timer
{
    int hours = 0;
    int minutes = 0;
    int seconds = 0;

    public Timer()
    {
        
    }

	public Timer(int hours,int minutes,int seconds)
	{
        
	}

    public int Hours
    {
        get
        {
            return hours;
        }
        set
        {
            hours = value;
        }
    }

    public int Minutes
    {
        get
        {
            return minutes;
        }
        set
        {
            minutes = value;
        }

    }

    public int Seconds
    {
        get
        {
            return seconds;
        }
        set
        {
            seconds = value;
        }
               
    }
}
