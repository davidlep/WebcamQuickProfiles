using System.Drawing;
using System.Reflection;

namespace WebcamQuickProfiles.GUI
{
    public class IconService
    {
        public Icon GetIcon()
        {
            var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.icon.ico";
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(fileName);

            return new Icon(stream);
        }
    }
}
