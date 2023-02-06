// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("EdqhzWBNzRuDWiPHcsdn/4jx2hO+BXtOAlPNVNnpbu9a6U5eXffzVtfbvMJhKjj8lRFgWeNBCo07AsmUGqLcRz22PWcbL1RcXlVGxd7c4PB9U14tuBffHrmtaQwcfbPepcNMbIaCtXE8H69g5xehE0PESNJA8HtHS8jGyflLyMPLS8jIyQG4LBtYsqokI7TvM9rwipwm96HuPpS1T0Jl65sRMOBGuEKzF9HSCLVBX1nz7Q7JaJGUvC9FSNnF92n9CmyKtaymSBPWg1WkcAkJsVICVxbpxxVNP7JSG+awASCvGAT3hPjRo96nSd3DhaQI+UvI6/nEz8DjT4FPPsTIyMjMycrR+qD42Lb0CpCm7o0jSlckgwA9G9KKZJLvyNHzjsvKyMnI");
        private static int[] order = new int[] { 13,7,8,9,8,12,7,11,11,10,11,12,13,13,14 };
        private static int key = 201;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
