using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject uiPanel;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void PlayVideo()
    {
        uiPanel.SetActive(true);
        videoPlayer.Play();
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        uiPanel.SetActive(false);
    }
}