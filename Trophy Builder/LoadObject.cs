using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trophy_Builder
{
    public class LoadObject
    {
        public string saveGameNameInput = "";
        public string saveGameIDInput = "";
        public string savePasswordInput = "";
        public string saveGameImageDirectory = "";
        public bool isLocked;
        public List<TrophyItem> saveListOfTrophies = new List<TrophyItem>();

        public LoadObject()
        {

        }

    }
}
