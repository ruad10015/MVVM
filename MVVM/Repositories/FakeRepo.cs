﻿using MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Repositories
{
    public class FakeRepo
    {
        public List<Printer> GetAll()
        {
            return new List<Printer>
            {
                new Printer{Id=1,Color="Red",Model="R100",Vendor="Canon"},
                new Printer{Id=2,Color="Blue",Model="C200",Vendor="HP"},
                new Printer{Id=3,Color="SkyBlue",Model="S100",Vendor="Epson"},
                new Printer{Id=4,Color="Indigo",Model="RR00",Vendor="VARTA"}
            };
        }
    }
}
