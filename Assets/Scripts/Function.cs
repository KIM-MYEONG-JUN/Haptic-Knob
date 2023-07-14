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


    string power = null;
    // string Mode_Text = "OFF";
    char dirc;
    int speed = 0;

    int now_loc = 0;
    // int mode = 0;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_SerialPort.Open();
        // ScriptText.text = "Selected Mode : " + Mode_Name[mode];
        m_SerialPort.ReadTimeout = 100;
        m_SerialPort.WriteTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {

        // ScriptText.text = "Selected Mode : " + Mode_Name[mode];
        if (m_SerialPort.IsOpen)
        {
            if (m_SerialPort.BytesToRead > 0) // 버퍼에 읽을 수 있는 바이트가 있는지 확인합니다.
            {

                m_Data = m_SerialPort.ReadLine();
                m_SerialPort.DiscardInBuffer();
                Debug.Log(m_Data);


                if (m_Data[0] == 'C')
                {
                    count++;
                }

                if (m_Data[0] == 'W')
                {
                    count--;
                }
            }
        }
        else
        {
            m_SerialPort.Open();
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
        m_SerialPort.Write("S"); ;
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
