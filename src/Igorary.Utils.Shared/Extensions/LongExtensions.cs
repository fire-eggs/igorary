
namespace Igorary.Utils.Utils.Extensions
{
    public static class LongExtensions
    {
        public static string ToKB(this long bytes) {
            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (int i = 0; i < suffix.Length; i++) {
                if (byteNumber < 1000)
                    if (i == 0)
                        return string.Format("{0} {1}", byteNumber, suffix[i]);
                    else
                    {
                        int val = (int)(byteNumber*100); // KBR don't round up, round down. Takes 0.998M -> 0.99M instead of 1.00M. 
                        byteNumber = val/100.0f;         // TODO need to test more!
                        return string.Format("{0:0.#0} {1}", byteNumber, suffix[i]);
                    }
                byteNumber /= 1024;
            }
            return string.Format("{0:N} {1}", byteNumber, suffix[suffix.Length - 1]);
        }

        public static string ToGB(this long bytes) {
            float byteNumber = bytes;
            byteNumber /= (1024 * 1024 * 1024);
            return string.Format("{0:0.00} GB", byteNumber);
        }

        public static string ToKBAndB(this long bytes) {

            // KBR TODO does this need to be fixed to round-down, see ToKB above?

            string[] suffix = { "B", "KB", "MB", "GB", "TB" };
            float byteNumber = bytes;
            for (int i = 0; i < suffix.Length; i++) {
                if (byteNumber < 1000)
                    if (i == 0)
                        return string.Format("{0} {1}", byteNumber, suffix[i]);
                    else
                        return string.Format("{0:0.#0} {1} (bytes: {2:#,##0})", byteNumber, suffix[i], bytes);
                byteNumber /= 1024;
            }
            return string.Format("{0:N} {1} (bytes: {2:#,##0})", byteNumber, suffix[suffix.Length - 1], bytes);
        }
    }
}
