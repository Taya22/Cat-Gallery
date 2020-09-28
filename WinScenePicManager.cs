using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScenePicManager : MonoBehaviour
{
    [SerializeField] private List<Image> winCatImages;

    private void Start()
    {
        ImageToShow();
    }

    void ImageToShow()
    {
        var imageIndex = SceneLoader.winImageIndex;
        foreach (var image in winCatImages)
        {
            if (imageIndex == winCatImages.IndexOf(image))
            {
                image.gameObject.SetActive(true);
            }
            else
            {
                image.gameObject.SetActive(false);
            }
        }
    }
}
