﻿using System.Collections.Generic;
using et12.edu.ar.AGBD.Ado;
using Espuchi.Core;

namespace Espuchi.AdoEt12;
public class AdoEt12 : IAdo
{
    public AdoAGBD Ado { get; set; }
    public MapBanda MapBanda { get; set; }
    public AdoEt12(AdoAGBD ado)
    {
        Ado = ado;
        MapBanda = new MapBanda(ado);
    }
    public void AltaBanda(Banda banda) => MapBanda.AltaBanda(banda);
    public List<Banda> ObtenerBanda() => MapBanda.ObtenerBanda();
}
