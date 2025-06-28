﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Tpi.Application.Dtos
{
    public record CustomerResponse(Guid Id, string Name, string Email, string PhoneNumber);
    public record CustomerRequest(string Name, string Email, string PhoneNumber);
}
