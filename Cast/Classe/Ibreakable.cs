﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catapulte.Classe
{
    interface Ibreakable
    {

        int Life { get; set; }

        Boolean checklife();
    }
}
