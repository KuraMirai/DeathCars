using System;
using System.Collections.Generic;
using UI.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapSelector : MonoBehaviour, IUICurrentSelectableById
{
    [SerializeField] 
    private TrackButtonView trackButtonPrefab;
    [SerializeField]
    private Image forwardImage;
    [SerializeField] 
    private Image backwardImage;
    /*[SerializeField] 
    private Button backButton;
    [SerializeField] 
    private Button forwardButton;*/
    [SerializeField] 
    private RectTransform contentRect;
    [SerializeField]
    private float snapSpeed = 3f;
    [SerializeField]
    private List<TrackPreview> previewTrackElements;
    /*[Range(1f, 20f)] 
        public float scaleSpeed;*/


    private TrackButtonView[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;
    private Vector2 contentVector;
    private int selectedPanID;

    public event Action<TrackPreview> ButtonClicked; 
    public event Action<TrackPreview> ButtonSelected;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            GoBackward();
        if (Input.GetKeyDown(KeyCode.RightArrow))
            GoForward();
    }

    public void Init()
    {
        instPans = new TrackButtonView[previewTrackElements.Count];
        pansPos = new Vector2[previewTrackElements.Count];
        pansScale = new Vector2[previewTrackElements.Count];
        for (int i = 0; i < previewTrackElements.Count; i++)
        {
            TrackButtonView track = Instantiate(trackButtonPrefab, transform, false);
            track.Init(previewTrackElements[i]);
            track.ButtonClicked += OnButtonClicked; 
            track.ButtonSelected += OnButtonSelected; 
            instPans[i] = track;
            if (i == 0) continue;
            pansPos[i] = -instPans[i].transform.localPosition;
        }
        selectedPanID = 0;
        CheckHideButtons();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < previewTrackElements.Count; i++)
        {
            contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, -instPans[selectedPanID].transform.localPosition.x, snapSpeed * Time.deltaTime);
            contentRect.anchoredPosition = contentVector;
            /*var image = instPans[i].GetComponentInChildren<Image>();
            var tempcolor = image.color;
            tempcolor.a = selectedPanID == i ? 1 : 0; 
            image.color = tempcolor;*/
            //Scale math if we need it
            /*float scale = Mathf.Clamp(1 / distance, 0.5f, 1f);
                pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale,
                    scaleSpeed * Time.fixedDeltaTime);
                pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale,
                    scaleSpeed * Time.fixedDeltaTime);
                instPans[i].transform.localScale = pansScale[i];*/
        }
    }

    private void OnButtonClicked(TrackPreview data)
    {
        ButtonClicked?.Invoke(data);
    }
    
    private void OnButtonSelected(TrackPreview data)
    {
        ButtonSelected?.Invoke(data);
    }
    
    public void SetSelectedElement(int id)
    {
        selectedPanID = id;
        EventSystem.current.SetSelectedGameObject(instPans[id].gameObject);
    }

    public int GetLastClickedItemId(TrackPreview lastClickedItem)
    {
        int id = 0;
        for (var i = 0; i < previewTrackElements.Count; i++)
        {
            var previewTrackElement = previewTrackElements[i];
            if (lastClickedItem == previewTrackElement)
            {
                id = i;
                break;
            }
        }

        return id;
    }

    private void GoForward()
    {
        selectedPanID++;
        selectedPanID = Mathf.Clamp(selectedPanID, 0, previewTrackElements.Count - 1);
        CheckHideButtons();
    }

    private void GoBackward()
    {
        selectedPanID--;
        selectedPanID = Mathf.Clamp(selectedPanID, 0, previewTrackElements.Count - 1);
        CheckHideButtons();
    }

    private void CheckHideButtons()
    {
        forwardImage.gameObject.SetActive(selectedPanID != previewTrackElements.Count - 1);
        backwardImage.gameObject.SetActive(selectedPanID != 0);
        /*forwardButton.gameObject.SetActive(selectedPanID != previewTrackElements.Count - 1);
        backButton.gameObject.SetActive(selectedPanID != 0);*/
    }
}