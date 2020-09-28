using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryPicManager : MonoBehaviour
{
    [SerializeField] private List<Image> catImages;

    private void Start()
    {
        ImageToShow();
    }

    void ImageToShow()
    {
        var imageIndex = SceneLoader.imageToLoadIndex;
        foreach (var image in catImages)
        {
            if (imageIndex == catImages.IndexOf(image))
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
