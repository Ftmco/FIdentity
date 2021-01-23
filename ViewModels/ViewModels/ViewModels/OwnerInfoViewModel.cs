﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record OwnerInfoViewModel
{
    public string UserProfileImageName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public int AppCount { get; set; }
}