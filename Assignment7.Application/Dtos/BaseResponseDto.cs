﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Application.Dtos
{
    public class BaseResponseDto
    {
        public string Status { get; set; } = null!;

        public string Message { get; set; } = null!;
    }
}
