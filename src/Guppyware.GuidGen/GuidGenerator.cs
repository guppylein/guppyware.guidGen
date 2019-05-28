using System;
using System.Windows.Forms;

namespace Guppyware.GuidGen
{
    public class GuidGenerator
    {
        public static string Generate(bool copyClipboard = true)
        {
            var guid = Guid.NewGuid().ToString();

            if (copyClipboard)
                Clipboard.SetText(guid);

            return guid;
        }
    }
}