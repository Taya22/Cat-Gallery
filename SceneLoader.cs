using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
   private int catPicAmmount = 30;
   public static int imageToLoadIndex = 0;
   public static int winImageIndex = 0;

   public int winCount = 0;
   [SerializeField] private int playAgainWC = 0;

   private int galleryPageIndex;
   
   void Awake()
   {
      DontDestroyLoader();
      LoadSavedData();
   }

   void DontDestroyLoader()
   {
      GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneLoader");

      if (objs.Length > 1)
      {
         Destroy(this.gameObject);
      }

      DontDestroyOnLoad(this.gameObject);
   }

   #region Game Saver

   private void SaveWinData()
   {
      PlayerPrefs.SetInt("WinData", winCount);
      PlayerPrefs.SetInt("WinData2", playAgainWC);
      PlayerPrefs.Save();
   }
   private void LoadSavedData()
   {
      winCount = PlayerPrefs.GetInt("WinData");
      playAgainWC = PlayerPrefs.GetInt("WinData2");
   }

   #endregion

   #region SceneLoader

   public void LoadWinScene()
   {
      if (winCount < catPicAmmount)
      {
         winImageIndex = winCount;
         SceneManager.LoadScene(6);
         winCount++;
      }
      else
      {
         if (playAgainWC >= catPicAmmount)
         {
            playAgainWC = 0;
         }

         winImageIndex = playAgainWC;
         winCount = catPicAmmount;
         SceneManager.LoadScene(6);
         playAgainWC++;
      }
      SaveWinData();
   }

   public void LoadGameScene()
   {
      SceneManager.LoadScene(5);
   }

   public void LoadMenuScene()
   {
      SceneManager.LoadScene(0);
   }
   
   public void LoadGalleryScene()
   {
      SceneManager.LoadScene(1);
   }

   public void GalleryLeftArrow()
   {
      if (SceneManager.GetActiveScene().buildIndex == 1)
      {
         SceneManager.LoadScene(3);
      }
      else if(SceneManager.GetActiveScene().buildIndex == 3)
      {
         SceneManager.LoadScene(2);
      }
      else if(SceneManager.GetActiveScene().buildIndex == 2)
      {
         SceneManager.LoadScene(1);
      }
   }

   public void GalleryRightArrow()
   {
      if (SceneManager.GetActiveScene().buildIndex == 1)
      {
         SceneManager.LoadScene(2);
      }
      else if(SceneManager.GetActiveScene().buildIndex == 2)
      {
         SceneManager.LoadScene(3);
      }
      else if(SceneManager.GetActiveScene().buildIndex == 3)
      {
         SceneManager.LoadScene(1);
      }
   }

   public void LoadGalleryCatScene(int imageIndex)
   {
      galleryPageIndex = SceneManager.GetActiveScene().buildIndex;
      imageToLoadIndex = imageIndex;
      SceneManager.LoadScene(4);
   }

   public void BackButtonCatScene()
   {
      SceneManager.LoadScene(galleryPageIndex);
   }

   #endregion

   public void QuitGame()
   {
      Application.Quit();
   }
}
