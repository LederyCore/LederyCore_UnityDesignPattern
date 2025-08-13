namespace MVP_Architecture
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using Utill;

    /// <summary>
    /// UI View의 기본 추상 클래스.
    /// MVP 패턴에서 View 계층의 공통 기능을 제공합니다.
    /// Abstract base class for UI Views.
    /// Provides common functionality for the View layer in the MVP architecture.
    /// </summary>
    public abstract class View_Base : MonoBehaviour
    {
        #region Fields
        /// <summary>
        /// UI Open 시 호출되는 이벤트
        /// Event invoked when the UI is opened.
        /// </summary>
        private event Action OnOpen;

        /// <summary>
        /// UI Close 시 호출되는 이벤트
        /// Event invoked when the UI is closed.
        /// </summary>
        private event Action OnClose;
        #endregion

        #region Methods
        /// <summary>
        /// UI 초기화 메서드. 부모 앵커 설정, RectTransform 초기화, 콜백 등록을 수행합니다.
        /// Initializes the UI: sets the parent anchor, resets RectTransform, and registers callbacks.
        /// </summary>
        /// <param name="anchor">UI를 붙일 부모 Transform / Parent transform to attach the UI to</param>
        /// <param name="callbacks">UI 열림/닫힘 시 실행할 콜백 리스트 / Callbacks for open/close events</param>
        public virtual void Init(Transform anchor, UICallbacks callbacks = null)
        {
            Utill.Log($"{GetType()}:: UI Initialize");

            // 부모 설정
            // Set parent transform
            transform.SetParent(anchor);

            // RectTransform 존재 여부 확인
            // Ensure RectTransform exists
            var rectTransform = GetComponent<RectTransform>();
            if (!rectTransform)
            {
                Utill.LogError($"{GetType()}:: RectTransform not found");
                return;
            }

            // 위치, 스케일, 여백 초기화
            // Reset position, scale, and offsets
            rectTransform.localPosition = Vector3.zero;
            rectTransform.localScale = Vector3.one;
            rectTransform.offsetMin = Vector3.zero;
            rectTransform.offsetMax = Vector3.zero;

            // Open/Close 콜백 등록
            // Register open/close callbacks
            if (callbacks != null)
            {
                foreach (var open in callbacks.OnOpens)
                    OnOpen += open;
                foreach (var close in callbacks.OnCloses)
                    OnClose += close;
            }
        }

        /// <summary>
        /// UI를 열 때 호출. OnOpen 이벤트 실행.
        /// Opens the UI and invokes OnOpen event.
        /// </summary>
        public virtual void Open() => OnOpen?.Invoke();

        /// <summary>
        /// UI를 닫을 때 호출. OnClose 이벤트 실행.
        /// Closes the UI and invokes OnClose event.
        /// </summary>
        public virtual void Close() => OnClose?.Invoke();

        /// <summary>
        /// Open 이벤트 콜백 추가.
        /// Adds a callback to the OnOpen event.
        /// </summary>
        public void AddOpenCallback(Action callback) => OnOpen += callback;

        /// <summary>
        /// Close 이벤트 콜백 추가.
        /// Adds a callback to the OnClose event.
        /// </summary>
        public void AddCloseCallback(Action callback) => OnClose += callback;

        private void OnDestroy()
        {
            // UI가 파괴될 때 Open/Close 콜백 제거
            // Remove Open/Close callbacks when the UI is destroyed
            OnOpen = null;
            OnClose = null;
        }
        #endregion
    }

    /// <summary>
    /// UI 열림/닫힘 시 실행할 콜백 리스트
    /// Holds lists of callbacks for UI open and close events.
    /// </summary>
    public class UICallbacks
    {
        /// <summary>
        /// Open 시 실행할 콜백 목록 / List of callbacks to execute on UI open
        /// </summary>
        public List<Action> OnOpens = new();

        /// <summary>
        /// Close 시 실행할 콜백 목록 / List of callbacks to execute on UI close
        /// </summary>
        public List<Action> OnCloses = new();
    }
}
