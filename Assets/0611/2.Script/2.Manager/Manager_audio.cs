using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_audio : MonoBehaviour
{
    public static Manager_audio instance = null;
    private AudioSource Hover;
    private AudioSource Click;
    // Start is called before the first frame update
    // 각 볼륨 값 정의하고
    // 팝업이 열릴 때 마다 한 번 값을 가져와서 슬라이더를 조절해준다

    //각 사운드의 볼륨을 일괄적으로 지정해주고 그것에 맞춰서 될지 한 번 확인해보자


    private float All_volume = 1f;
    private float Effect_volume = 0.5f;
    private float Narr_volume = 0.5f;
    private float BGM_volume = 0.1f;

    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else
        {
            if (instance != this) //instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject); //�� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    void Start()
    {
        Init_sound();
    }

    public float Get_all_volume()
    {
        return All_volume;
    }
    public float Get_Effect_volume()
    {
        return Effect_volume;
    }
    public float Get_Narr_volume()
    {
        return Narr_volume;
    }
    public float Get_BGM_volume()
    {
        return BGM_volume;
    }

    public void Get_hover()
    {
        Hover.Play();
        //Debug.Log("hover");
    }

    public void Get_click()
    {
        Click.Play();
        //Debug.Log("click");
    }

   
    private void OnLevelWasLoaded(int level)
    {
        Init_sound();
    }
    private void Init_sound()
    {
        Hover = this.transform.GetChild(0).gameObject.GetComponent<AudioSource>();
        Click = this.transform.GetChild(1).gameObject.GetComponent<AudioSource>();
       
    }
    public void Set_all_sound_volume(float volume)
    {
        if(volume == 0)
        {
            Hover.mute = true;
            Click.mute = true;
           
        }
        else if(volume == 1)
        {
            Hover.mute = false;
            Click.mute = false;
           
        }
    }

    public void Set_effect_sound_volume(float volume)
    {
        Hover.volume = volume;
        Click.volume = volume;
       
    }

}
