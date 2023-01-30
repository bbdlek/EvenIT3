// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("r6g/ZLhRewEXrXwqZbUfPsTJ7mCRKVfMtj227JCk39fV3s1OVVdre10I3i/7goI62YncnWJMnsa0OdmQ4xofN6TOw1JOfOJ2gecBPictw5j22NWmM5xUlTIm4oeX9jhVLkjH5207iqskk498D3NaKFUswlZIDi+DmlEqRuvGRpAI0ahM+UzsdAN6UZhcUDdJ6qGzdx6a69JoyoEGsIlCHxCau2vNM8k4nFpZgz7K1NJ4ZoVCNY7wxYnYRt9SYuVk0WLF1dZ8eN3AQ01CcsBDSEDAQ0NCijOnkNM5IVpxK3NTPX+BGy1lBqjB3K8Ii7aQcsBDYHJPREtoxArEtU9DQ0NHQkENCT76t5Qk62ycKpjIT8NZy3vwzFkB7xlkQ1p4BUBBQ0JD");
        private static int[] order = new int[] { 11,9,4,10,4,5,13,8,13,13,13,13,13,13,14 };
        private static int key = 66;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
