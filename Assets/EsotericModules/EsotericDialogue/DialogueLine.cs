using System.Collections.Generic;
using System;

namespace EsotericUtilities.Dialogue
{
    public class DialogueLine
    {
        //Store information about dialogue options
        public readonly bool HasOptions;

        //Store all text and effects in this line as a list of tuples
        public readonly List<Tuple<List<DialogueEffect>, string>> Text;
    }
}
