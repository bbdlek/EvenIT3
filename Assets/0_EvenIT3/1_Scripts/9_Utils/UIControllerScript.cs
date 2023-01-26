using System.Collections;
using System.Collections.Generic;
using DarkTonic.MasterAudio;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIControllerScript : MonoBehaviour
    {
        private GameObject _rootObject;
        protected GameObject SceneScriptObject;
        [HideInInspector] public bool initFinish;

        protected enum SortOrder
        {
            Background = 0,
            Main = 1,
            Overlay = 2,
            Popup = 3,
            Alert = 4
        }

        [SerializeField] protected SortOrder sortOrder = SortOrder.Main;

        private Dictionary<string, GameObject> _uiDictionary;

        protected GameObject NowClickBtnUI;

        [SerializeField] protected bool isAutoScaleMode = true;
        [SerializeField] [Range(0f, 1f)] protected float isScaleModeValue = 1f;

        public virtual void InitSetup(GameObject scriptObject)
        {
            if (isAutoScaleMode)
            {
                var scaler = GetComponent<CanvasScaler>();
                scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
                if (Screen.height / (float) Screen.width > 0.5625f) // Change Canvas Reference
                    scaler.matchWidthOrHeight = 1f - isScaleModeValue;
                else
                    scaler.matchWidthOrHeight = isScaleModeValue;
            }

            GetComponent<Canvas>().sortingOrder = (int) sortOrder;
            _uiDictionary = new Dictionary<string, GameObject>();
            _rootObject = gameObject;

            AddAllChildrenDictionary(_rootObject);

            SceneScriptObject = scriptObject;
            initFinish = true;
        }

        private void AddAllChildrenDictionary(GameObject selectObject)
        {
            try
            {
                _uiDictionary.Add(selectObject.name, selectObject);
            }
            catch
            {
                if (!selectObject.GetComponent<TMP_SubMeshUI>()) Debug.LogError($"{selectObject.name} is OverlapName in {gameObject}");
            }

            var tempChildCount = selectObject.transform.childCount;
            if (tempChildCount > 0)
                for (var i = 0; i < tempChildCount; i++)
                    AddAllChildrenDictionary(selectObject.transform.GetChild(i).gameObject);
        }

        public GameObject FindUIObject(string objectName)
        {
            try
            {
                return _uiDictionary[objectName];
            }
            catch
            {
                Debug.LogWarning($"{objectName} : Not Found");
                return null;
            }
        }

        protected virtual void ButtonOnClick(int clickBtn)
        {
            NowClickBtnUI = EventSystem.current.currentSelectedGameObject;

            Debug.Log($"ClickBtn : {NowClickBtnUI.name}");
        }
    }
