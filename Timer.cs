using System;

public class Timer

{
	public Timer()
	{
        

	}

    private int setHours()
    {
        try
        {
            hours = Convert.ToInt32(txtHours.Text);
            lblHours.Text = hours.ToString();
        }
        catch (ArgumentException)
        {

        }
        finally
        {

        }

        return hours;
    }

    private int setMinutes()
    {
        try
        {
            minutes = Convert.ToInt32(txtMinutes.Text);
            lblMinutes.Text = minutes.ToString();
        }
        catch (ArgumentException)
        {

        }
        finally
        {

        }
        return minutes;
    }

    public int setSeconds()
    {
        try
        {
            seconds = Convert.ToInt32(txtSeconds.Text);
            lblSeconds.Text = seconds.ToString();
        }
        catch (ArgumentException)
        {

        }
        finally
        {

        }
        return seconds;
    }
}
