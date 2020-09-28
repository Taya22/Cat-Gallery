using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GalleryScript : MonoBehaviour
{
    [SerializeField] private List<Image> censoredImages;
    private int _winCount;
    [SerializeField]private int pageWC;

    private void Start()
    {
        GalleryPageCheck();
        UnlockImages();
    }

    void UnlockImages()
    {
        foreach (var image in censoredImages)
        {
            if (pageWC - 1 >= censoredImages.IndexOf(image))
            {
                image.gameObject.SetActive(false);
            }
            else
            {
                image.gameObject.SetActive(true);
            }
        }
    }

    void GalleryPageCheck()
    {
        _winCount = FindObjectOfType<SceneLoader>().winCount;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            pageWC = _winCount;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            pageWC = _winCount - 10;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            pageWC = _winCount - 20;
        }
    }
}