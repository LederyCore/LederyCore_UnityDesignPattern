namespace Utill
{
    using System;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// 유틸리티 메서드 모음 클래스
    /// Utility methods collection class
    /// </summary>
    public static class Utill
    {
        #region DEBUG
        /// <summary>
        /// [DEV 모드 전용] 현재 시각과 함께 일반 로그 출력
        /// [DEV mode only] Prints a standard log with current timestamp
        /// </summary>
        [Conditional("DEV")]
        public static void Log(string msg)
        {
            UnityEngine.Debug.LogFormat("[{0}] {1}", DateTime.Now.ToString("yyyy,MM,dd HH-mm-ss.fff"), msg);
        }

        /// <summary>
        /// [DEV 모드 전용] 현재 시각과 함께 경고 로그 출력
        /// [DEV mode only] Prints a warning log with current timestamp
        /// </summary>
        [Conditional("DEV")]
        public static void LogWarning(string msg)
        {
            UnityEngine.Debug.LogWarningFormat("[{0}] {1}", DateTime.Now.ToString("yyyy,MM,dd HH-mm-ss.fff"), msg);
        }

        /// <summary>
        /// 현재 시각과 함께 에러 로그 출력
        /// Prints an error log with current timestamp
        /// </summary>
        public static void LogError(string msg)
        {
            UnityEngine.Debug.LogErrorFormat("[{0}] {1}", DateTime.Now.ToString("yyyy,MM,dd HH-mm-ss.fff"), msg);
        }
        #endregion

        #region Component
        /// <summary>
        /// 지정한 GameObject에서 컴포넌트를 가져오거나 없으면 새로 추가합니다.
        /// </summary>
        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            var comp = go.GetComponent<T>();
            if (comp == null)
                comp = go.AddComponent<T>();
            return comp;
        }

        /// <summary>
        /// 지정한 Component에서 대상 컴포넌트를 가져오거나 없으면 새로 추가합니다.
        /// 사용 예: this.GetOrAddComponent<Rigidbody>()
        /// </summary>
        public static T GetOrAddComponent<T>(this Component c) where T : Component
        {
            return c.gameObject.GetOrAddComponent<T>();
        }
        #endregion
    }
}
