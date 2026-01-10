namespace MornLib
{
    /// <summary> MornSaveKeyLoggerモジュール用のログ出力クラス </summary>
    internal static class MornSaveKeyLogger
    {
        /// <summary> Debug.Logラッパー </summary>
        public static void Log(string message)
        {
            MornSaveKeyGlobal.I.Logger.LogInternal(message);
        }

        /// <summary> Debug.LogErrorラッパー </summary>
        public static void LogError(string message)
        {
            MornSaveKeyGlobal.I.Logger.LogErrorInternal(message);
        }

        /// <summary> Debug.LogWarningラッパー </summary>
        public static void LogWarning(string message)
        {
            MornSaveKeyGlobal.I.Logger.LogWarningInternal(message);
        }
    }
}