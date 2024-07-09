﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeggieRecipes.Domain.Interfaces;

namespace VeggieRecipes.Domain.Model
{
    public class Mesurament : AuditableEntity, IEntity
    {
        public int Id { get; set; }
        public string MesuramentTitle { get; set; }
    }
}
