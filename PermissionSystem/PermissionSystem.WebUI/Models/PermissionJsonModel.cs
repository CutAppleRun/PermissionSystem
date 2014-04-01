using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PermissionSystem.WebUI.Models
{
    public class PermissionJsonModel
    {
        public long Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public List<PermissionJsonModel> children { get; set; }
    }
}