﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class StarFieldManagerComponent : MonoBehaviour 
{
    public GameObject StarSprite;
    public int NumberOfStars = 10;

    private float[] mScreenX;
    private float[] mScreenY;

    private List<GameObject> mStars;

    private Rect mWorldViewPort;

    private float[] mX;
    private float[] mY;
    private float[] mZ;
    private float[] mVX;

    void Start() 
    {
        mStars = new List<GameObject>();

        mScreenX = new float[NumberOfStars];
        mScreenY = new float[NumberOfStars];

        mX = new float[NumberOfStars];
        mY = new float[NumberOfStars];

        mZ = new float[NumberOfStars];
        mVX = new float[NumberOfStars];

        Vector3 mV1 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMin, Camera.main.pixelRect.yMin, 0F));
        Vector3 mV2 = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelRect.xMax, Camera.main.pixelRect.yMax, 0F));
        Vector3 mV3 = (mV2 - mV1);
  
        mWorldViewPort = new Rect(mV1.x, mV1.y, mV3.x , mV3.y);

        GameObject mTempObject = (GameObject)GameObject.Instantiate(StarSprite);

        for (int A = 0; A < NumberOfStars; A++)
        {
            mX[A] = GetRandom(mWorldViewPort.xMin, mWorldViewPort.xMax);
            mY[A] = GetRandom(mWorldViewPort.yMin, mWorldViewPort.yMax);
            mZ[A] = 1F;
            mVX[A] = GetRandom(0.001F, 0.01F);

            GameObject mObject = Instantiate(mTempObject);
            mObject.name =  String.Format("Star - {0}" , A);
            mObject.transform.SetParent(this.transform, true); 
            //mObject.GetComponent<SpriteRenderer>().color = new Color(0.8F, 0.8F, 0.8F);  
            mScreenX[A] = (mX[A] / mZ[A]);
            mScreenY[A] = (mY[A] / mZ[A]);

            mObject.transform.position = new Vector3(mScreenX[A], mScreenY[A], 1F);
 
            mStars.Add(mObject);
        }

        Destroy(mTempObject);
	}
	
	 void Update () 
  {
   if (NumberOfStars > 0)
     {
      for (int A = 0; A < NumberOfStars; A++)
      {
       mX[A] -= mVX[A];

       if (mZ[A] > 0.0)
         {
          mScreenX[A] = (mX[A] / mZ[A]);
          mScreenY[A] = (mY[A] / mZ[A]);

          if (mWorldViewPort.Contains(new Vector3(mScreenX[A], mScreenY[A], 1F)) == false)
            {
                        mX[A] = mWorldViewPort.xMax;
                        mY[A] = GetRandom(mWorldViewPort.yMin, mWorldViewPort.yMax);
                        mZ[A] = 1F;
                        mVX[A] = GetRandom(0.001F, 0.007F);
                        mStars[A].transform.position = new Vector3(mX[A], mY[A], 1F);
                        float randomSize = 2f * mVX[A] * 100;
                        mStars[A].transform.localScale = new Vector3(randomSize, randomSize, 1F);
            }
         }
                else
                {
                    continue;
                }

       mStars[A].transform.position = new Vector3(mScreenX[A], mScreenY[A], 1f);
      }
     }	
	 }

  private float GetRandom(float min, float max)
  {
   return UnityEngine.Random.Range(min, max);
  }
}
