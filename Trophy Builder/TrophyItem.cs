using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static Trophy_Builder.Manager;
using Microsoft.Xna.Framework.Graphics;

namespace Trophy_Builder
{
    public class TrophyItem
    {
        public string trophyName = "";
        public string trophyDescription = "";
        public int trophyLevel = 1;
        public bool isVitaIslandIceTea = false;
        public bool isHidden = false;
        public string fileDirectory = "";

        public TrophyItem()
        {
            
        }

        public void UpdateImage()
        {
            if(fileDirectory != "")
            {
                if (File.Exists(fileDirectory) == true)
                {
                    FileStream stream = new FileStream(fileDirectory, FileMode.Open, FileAccess.Read);

                    trophyImageTexture = Texture2D.FromStream(graphicsDevice, stream);
                }
            }
        }
    }
}
