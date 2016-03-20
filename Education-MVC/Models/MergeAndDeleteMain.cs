using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ceu_Education_MVC.Models
{
    public class MergeAndDeleteMain
    {
        public string personidleft { get; set; }
        public string personidright { get; set; }
        public bool SelectedOne { get; set; }
        public bool SelectedTwo{ get; set; }
    }
}