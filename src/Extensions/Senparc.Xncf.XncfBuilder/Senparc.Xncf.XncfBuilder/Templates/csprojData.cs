﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Senparc.Xncf.XncfBuidler.Templates
{
    public partial class csproj: IXncfTemplatePage
    {
        public string RelativeFilePath => $"{OrgName}.Xncf.{XncfName}.csproj";

        public string OrgName { get; set; }
        public string XncfName { get; set; }
        public string Version { get; set; }
        public string MenuName { get; set; }
        public string Description { get; set; }
    }
}