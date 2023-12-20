using System;
using System.Collections.Generic;

namespace SOLIDDb_15_12_23_.Models;

public partial class EmailMessage
{
    public int Id { get; set; }

    public string ToAddress { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Body { get; set; } = null!;
}
