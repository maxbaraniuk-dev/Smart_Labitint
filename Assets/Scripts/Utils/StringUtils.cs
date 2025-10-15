using System;

namespace Utils
{
    public class StringUtils
    {
        public static string FormatDistance(float distance)
        {
            return $"{distance:F1}m";
        }
        
        public static string FormatTime(float time)
        {
            return $"{TimeSpan.FromSeconds(time):mm\\:ss}";
        }
    }
}