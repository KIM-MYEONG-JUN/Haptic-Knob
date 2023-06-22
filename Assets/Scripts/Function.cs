using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using UnityEngine;
using UnityEngine.UI;


public class Function : MonoBehaviour
{
    //public static string Comport = "COM7";
    SerialPort m_SerialPort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
    string m_Data = null;
    char[] delimiterChars = { '$', ',', '#', ' ' };
    // public Text ScriptText;
    
    string power = null;
    // string Mode_Text = "OFF";
    char dirc;
    int speed = 0;
    // string[] Mode_Name = {"","Low ticks", "Middle ticks", "High ticks", "OFF" };
    
    int now_loc = 0;
    // int mode = 0;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_SerialPort.Open();
        // ScriptText.text = "Selected Mode : " + Mode_Name[mode];
        m_SerialPort.ReadTimeout = 300;
        m_SerialPort.WriteTimeout = 300;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            // ScriptText.text = "Selected Mode : " + Mode_Name[mode];
            if (m_SerialPort.IsOpen)
            {
                m_SerialPort.DiscardInBuffer();
                m_Data = m_SerialPort.ReadLine();
                // Debug.Log(m_Data);

                // string[] words = m_Data.Split(delimiterChars);
                // dirc = char.Parse(words[0]);
                // speed = int.Parse(words[1]);
                // now_loc = int.Parse(words[2]);

                // Debug.Log(m_Data);

                if (m_Data[0] == 'C')
                {
                    count += 1;

                    if (count > 1) count = 0;
                }

                if (m_Data[0] == 'W')
                {
                    count -= -1;

                    if (count < -1) count = 0;
                }
            }
        }
        catch (Exception e)
        {
            // Debug.Log(e);
        }
    }

    public void OnclickABumpy()
    {
        Debug.Log("Bumpy_50Hz");
        m_SerialPort.Write("1");
        // mode = 1;
    }

    public void OnclickBBumpy()
    {
        Debug.Log("Bumpy_100Hz");
        m_SerialPort.Write("2");
        // mode = 2;
    }

    public void OnclickCBumpy()
    {
        Debug.Log("Bumpy_200Hz");
        m_SerialPort.Write("3");
        // mode = 3;
    }

    public void OnclickOff()
    {
        Debug.Log("Off");
        m_SerialPort.Write("S");
        //mode = 4;
        //Mode_Text = "OFF";
    }

    public void OnApplicationQuit()
    {
        if (m_SerialPort == null)
            return;
        m_SerialPort.Write("S");;
        m_SerialPort.Close();
    }

    // public void Plus()
    // {
    //     if (!ScriptText != null)
    //     {
    //         ScriptText.text = Mode_Text;
    //     }
    // }
}
