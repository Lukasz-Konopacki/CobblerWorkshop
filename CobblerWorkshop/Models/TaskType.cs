﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Models
{
    public class TaskType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public double SuggestPrice { get; set; }
        public List<ResourcesPosition> Positions { get; set; }

        public TaskType(string name, double suggestPrice, List<ResourcesPosition>? positions = null)
        {
            Name = name;
            SuggestPrice = suggestPrice;
            Positions = positions ?? new List<ResourcesPosition>();
        }
        public TaskType() {}

        public override string ToString()
        {
            return Name;
        }
    }
}

