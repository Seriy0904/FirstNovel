using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOUGE
{
    public class DIALOUGE_LINE
    {
        public string speaker;
        public string dialouge;
        public string commands;

        public DIALOUGE_LINE(string speaker, string dialouge, string commands)
        {
            this.speaker = speaker;
            this.dialouge = dialouge;
            this.commands = commands;
        }
    }
}
